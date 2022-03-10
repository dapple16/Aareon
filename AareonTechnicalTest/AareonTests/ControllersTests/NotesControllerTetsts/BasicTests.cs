using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;

namespace AareonTests.ControllersTests.NotesControllerTetsts
{
	public class BasicTests
	{
		private Mock<ICrudBLProvider<NoteModel>> _crudBlMock;

		private TicketController InitialiseConstructor()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			var sut = new TicketController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void CanInitialise()
		{
			var sut = new TicketController(Mock.Of<ICrudBLProvider<NoteModel>>());
			Assert.NotNull(sut);
		}
	}
}