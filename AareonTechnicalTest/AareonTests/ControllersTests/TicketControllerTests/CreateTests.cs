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
	public class CreateTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void Create_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var ticketModel = new TicketModel();
			var result = sut.Create(ticketModel).Result;

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Create_VerifyCrudProviderIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Create(new TicketModel()).Result;
			_crudBlMock.Verify(v => v.Create(It.IsAny<TicketModel>()), Times.Once);
		}

		[Fact]
		public void Create_returnsTrueOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Create(new TicketModel())).Returns(Task.FromResult(true));
			TicketController sut = InitialiseConstructor();

			var result = sut.Create(new TicketModel()).Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<bool>(result.Value);
		}

		[Fact]
		public async void Create_returnsNocontentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Create(It.IsAny<TicketModel>())).ThrowsAsync(new Exception());
			TicketController sut = InitialiseConstructor();

			var result = await sut.Create( new TicketModel());

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
