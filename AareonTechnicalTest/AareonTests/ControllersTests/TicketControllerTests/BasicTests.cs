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
			var result = sut.Delete(1);
			_crudBlMock.Verify(v => v.Delete(It.IsAny<int>()), Times.Once);
		}
	}
}