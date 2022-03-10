using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AareonTests.ControllersTests.NotesControllerTetsts
{
	public class CreateTests
	{
		private Mock<ICrudBLProvider<NoteModel>> _crudBlMock;
		private TicketController InitialiseConstructor()
		{
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void Create_returns_Ok()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			TicketController sut = InitialiseConstructor();
			var model = new NoteModel();
			var result = sut.Create(model).Result;

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void Create_VerifyCrudProviderIsCalled()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			TicketController sut = InitialiseConstructor();
			var result = sut.Create(new NoteModel()).Result;
			_crudBlMock.Verify(v => v.Create(It.IsAny<NoteModel>()), Times.Once);
		}

		[Fact]
		public void Create_returnsTrueOnSuccess()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			_crudBlMock.Setup(s => s.Create(new NoteModel())).Returns(Task.FromResult(true));
			TicketController sut = InitialiseConstructor();

			var result = sut.Create(new NoteModel()).Result as OkObjectResult;

			_ = Assert.IsAssignableFrom<bool>(result.Value);
		}

		[Fact]
		public async void Create_returnsNocontentOnFail()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			_crudBlMock.Setup(s => s.Create(It.IsAny<NoteModel>())).ThrowsAsync(new Exception());
			TicketController sut = InitialiseConstructor();

			var result = await sut.Create(new NoteModel());

			_ = Assert.IsAssignableFrom<NoContentResult>(result);
		}
	}
}
