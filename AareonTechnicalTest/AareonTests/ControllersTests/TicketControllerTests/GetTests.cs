using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
			var result = sut.Get().Result;
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
			var retVal = new List<TicketModel> 
			{ 
				new TicketModel() 
			};
			_crudBlMock.Setup(s => s.Get()).Returns(Task.FromResult(retVal as IEnumerable<TicketModel>));
			TicketController sut = InitialiseConstructor();

			var result = sut.Get().Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<IEnumerable<TicketModel>>(result.Value);
		}

		[Fact]
		public async void Get_returnsNoContentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<TicketModel>>();
			_crudBlMock.Setup(s => s.Get()).ThrowsAsync(new Exception());
			TicketController sut = InitialiseConstructor();

			var result = await sut.Get();

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
