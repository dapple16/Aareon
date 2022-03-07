using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AareonTests.ControllersTests.TicketControllerTests
{
	public class PutTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void Put_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var ticketModel = new TicketModel();
			var result = sut.Put(0, ticketModel).Result;

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Put_VerifyCrudProviderIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Put(1, new TicketModel()).Result;
			_crudBlMock.Verify(v => v.Put(It.IsAny<int>(), It.IsAny<TicketModel>()), Times.Once);
		}


		[Fact]
		public void Put_returnsTrueOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Put(1, new TicketModel())).Returns(Task.FromResult(true));
			TicketController sut = InitialiseConstructor();

			var result = sut.Put(1, new TicketModel()).Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<bool>(result.Value);
		}

		[Fact]
		public async void Put_returnsNoContentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Put(It.IsAny<int>(), It.IsAny<TicketModel>())).ThrowsAsync(new Exception());
			TicketController sut = InitialiseConstructor();

			var result = await sut.Put(1, new TicketModel());

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
