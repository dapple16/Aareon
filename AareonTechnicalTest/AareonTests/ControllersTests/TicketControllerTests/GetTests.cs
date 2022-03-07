using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AareonTests.ControllersTests.TicketControllerTests
{
	public class GetTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void Get_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Get_VerifyCrudProviderGetIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_crudBlMock.Verify(v => v.Get(), Times.Once);
		}

		[Fact]
		public void Get_returnsModelOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Get()).Returns(new TicketModel());
			TicketController sut = InitialiseConstructor();

			var result = sut.Get() as OkObjectResult;

			_ = Assert.IsAssignableFrom<TicketModel>(result.Value);
		}

		[Fact]
		public void Get_returnsNocontentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Get()).Returns(() => throw new Exception());
			TicketController sut = InitialiseConstructor();

			var result = sut.Get();

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
