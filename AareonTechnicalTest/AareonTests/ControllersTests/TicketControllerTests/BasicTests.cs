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
		[Fact]
		public void CanInitialise()
		{
			var sut = new TicketController(Mock.Of<ICrudBLProvider<TicketModel>>());

			Assert.NotNull(sut);
		}

		[Fact]
		public void Get_returns_Ok()
		{
			var crudBlMock = Mock.Of<ICrudBLProvider<TicketModel>>();
			var sut = new TicketController(crudBlMock);
			var result = sut.Get();

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Put_returns_Ok()
		{
			var crudBlMock = Mock.Of<ICrudBLProvider<TicketModel>>();
			var sut = new TicketController(crudBlMock);
			var ticketModel = new TicketModel();
			var result = sut.Put(ticketModel);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Create_returns_Ok()
		{
			var crudBlMock = Mock.Of<ICrudBLProvider<TicketModel>>();
			var sut = new TicketController(crudBlMock);
			var ticketModel = new TicketModel();
			var result = sut.Create(ticketModel);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Delete_returns_Ok()
		{
			var crudBlMock = Mock.Of<ICrudBLProvider<TicketModel>>();
			var sut = new TicketController(crudBlMock);
			var ticketId = 1;
			var result = sut.Delete(ticketId);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
