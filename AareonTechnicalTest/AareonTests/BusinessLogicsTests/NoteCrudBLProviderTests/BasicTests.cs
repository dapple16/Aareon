using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using AareonTechnicalTest.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AareonTests.BusinessLogicsTests.NoteCrudBLProviderTests
{
	public class BasicTests
	{
		private Mock<INoteRepository> _noteRepository;
		private Mock<ITicketRepository> _ticketRepository;
		private Mock<IPersonRepository> _personRepository;
		public BasicTests()
		{
			AutoMapperHelper.Configure();
		}
		private NoteCrudBLProvider InitialiseContructor()
		{
			return new NoteCrudBLProvider(_noteRepository.Object, _ticketRepository.Object, _personRepository.Object);
		}

		[Fact]
		public void SmokeTest()
		{
			Assert.True(true);
		}

		[Fact]
		public void NoteBlConstructorInitialised()
		{
			_noteRepository = new Mock<INoteRepository>();
			NoteCrudBLProvider sut = InitialiseContructor();
			Assert.IsAssignableFrom<ICrudBLProvider<NoteModel>>(sut);
		}

		[Fact]
		public async void GetReturnsEnumerableOfNoteModel()
		{
			_noteRepository = new Mock<INoteRepository>();

			var retVal = new List<Note>
			{
				new Note()
				{
					Description= "First note",
					TicketId = 1
				},
				new Note()
				{
					Description= "Second note",
					TicketId = 2
				}
			};
			_noteRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Note>));

			NoteCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.IsAssignableFrom<IEnumerable<NoteModel>>(result);
			Assert.Equal(2, result.Count());

		}

		[Fact]
		public async void GetReturnsValidNoteModel()
		{
			_noteRepository = new Mock<INoteRepository>();

			var retVal = new List<Note>
			{
				new Note()
				{
					Description= "First note",
					TicketId = 1
				},
				new Note()
				{
					Description= "Second note",
					TicketId = 2
				}
			};
			_noteRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Note>));

			NoteCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.Equal("First note", result.FirstOrDefault().Description);

		}

		[Fact]
		public async void GetByIdReturnsNoteModel()
		{
			_noteRepository = new Mock<INoteRepository>();
			_noteRepository.Setup(s => s.FindById(2))
				.Returns(Task.FromResult(
					new Note()
					{
						Description = "Second note",
						TicketId = 2
					}));

			NoteCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get(2);

			Assert.Equal("Second note", result.Description);

		}

		[Fact]
		public async void UpdateNoteModel()
		{
			_noteRepository = new Mock<INoteRepository>();
			_noteRepository.Setup(s => s.Update(It.IsAny<Note>())).Returns(Task.FromResult(true));

			var NoteModel = new NoteModel()
			{
				Description = "First note",
				TicketId = 1
			};
			NoteCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Put(1, NoteModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of update

		[Fact]
		public async void AddNoteModel()
		{
			_noteRepository = new Mock<INoteRepository>();
			_noteRepository.Setup(s => s.Add(It.IsAny<Note>())).Returns(Task.FromResult(true));

			var NoteModel = new NoteModel()
			{
				Description = "First note",
				TicketId = 1
			};
			NoteCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Create(NoteModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of add

		[Fact]
		public async void VerifyDeleteNoteCallsPersonRepository()
		{
			_personRepository = new Mock<IPersonRepository>();
			_personRepository.Setup(s => s.FindById(2)).Returns(Task.FromResult(new Person { Forename = "Tester", IsAdmin = true }));

			_ticketRepository = new Mock<ITicketRepository>();
			_ticketRepository.Setup(s => s.FindById(1)).Returns(Task.FromResult(new Ticket { Content = "Ticket", PersonId = 2 }));

			_noteRepository = new Mock<INoteRepository>();

			_noteRepository.Setup(s => s.Remove(It.IsAny<Note>())).Returns(Task.FromResult(true));

			NoteCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Delete(1);

			_ticketRepository.Verify(v => v.FindById(1), Times.Once);
			_personRepository.Verify(v => v.FindById(2), Times.Once);
			Assert.True(result);
		}
	}
}
