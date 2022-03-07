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
	public class DeleteTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void Delete_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var ticketModel = new TicketModel();
			var result = sut.Delete(0).Result;

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Delete_VerifyCrudProviderIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Delete(1).Result;
			_crudBlMock.Verify(v => v.Delete(It.IsAny<int>()), Times.Once);
		}


		[Fact]
		public void Delete_returnsTrueOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Delete(1)).Returns(Task.FromResult(true));
			TicketController sut = InitialiseConstructor();

			var result = sut.Delete(1).Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<bool>(result.Value);
		}

		[Fact]
		public async void Delete_returnsNoContentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Delete(1)).ThrowsAsync(new Exception());
			TicketController sut = InitialiseConstructor();

			var result = await sut.Delete(1);

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
