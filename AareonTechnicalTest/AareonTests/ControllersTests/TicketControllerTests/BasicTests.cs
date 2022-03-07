using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;

namespace AareonTests.ControllersTest.TicketControllerTests
{
	public class BasicTests
	{
		private Mock<ICrudBLProvider<TicketModel>> _crudBlMock;

		private TicketController InitialiseConstructor()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void CanInitialise()
		{
			var sut = new TicketController(Mock.Of<ICrudBLProvider<TicketModel>>());
			Assert.NotNull(sut);
		}

		[Fact]
		public void Get_returns_Ok()
		{
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Get_VerifyCrudProviderGetIsCalled()
		{
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_crudBlMock.Verify(v => v.Get(), Times.Once);
		}

		[Fact]
		public void Put_returns_Ok()
		{
			TicketController sut = InitialiseConstructor();
			var ticketModel = new TicketModel();
			var result = sut.Put(0, ticketModel);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Get_VerifyCrudProviderPutIsCalled()
		{
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_crudBlMock.Verify(v => v.Put(It.IsAny<int>(), It.IsAny<TicketModel>()), Times.Once);
		}

		[Fact]
		public void Create_returns_Ok()
		{
			TicketController sut = InitialiseConstructor();
			var ticketModel = new TicketModel();
			var result = sut.Create(ticketModel);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Get_VerifyCrudProviderCreateIsCalled()
		{
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_crudBlMock.Verify(v => v.Create(It.IsAny<TicketModel>()), Times.Once);
		}

		[Fact]
		public void Delete_returns_Ok()
		{
			TicketController sut = InitialiseConstructor();
			var ticketId = 1;
			var result = sut.Delete(ticketId);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Get_VerifyCrudProviderDeleteIsCalled()
		{
			TicketController sut = InitialiseConstructor();
			var result = sut.Get();
			_crudBlMock.Verify(v => v.Delete(It.IsAny<int>()), Times.Once);
		}
	}
}