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
	public class GetByIdTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void GetById_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.GetById(1);
			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void GetById_VerifyCrudProviderGetIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.GetById(1);
			_crudBlMock.Verify(v => v.Get(It.IsAny<int>()), Times.Once);
		}

		[Fact]
		public void GetById_returnsModelOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Get(1)).Returns(Task.FromResult(new TicketModel()));
			TicketController sut = InitialiseConstructor();

			var result = sut.GetById(1).Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<TicketModel>(result.Value);
		}

		[Fact]
		public void GeByIdt_returnsNocontentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Get(1)).Returns(() => throw new Exception());
			TicketController sut = InitialiseConstructor();

			var result = sut.GetById(1);

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
