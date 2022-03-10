using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Controllers;
using Moq;
using Xunit;

namespace AareonTests.ControllersTests.NotesControllerTetsts
{
	public class BasicTests
	{
		private Mock<ICrudBLProvider<NoteModel>> _crudBlMock;

		private NoteController InitialiseConstructor()
		{
			_crudBlMock = new Mock<ICrudBLProvider<NoteModel>>();
			var sut = new NoteController(_crudBlMock.Object);
			return sut;
		}

		[Fact]
		public void CanInitialise()
		{
			var sut = new NoteController(Mock.Of<ICrudBLProvider<NoteModel>>());
			Assert.NotNull(sut);
		}
	}
}