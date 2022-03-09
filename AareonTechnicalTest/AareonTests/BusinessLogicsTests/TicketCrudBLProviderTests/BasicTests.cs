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

namespace AareonTests.BusinessLogicsTests.TicketCrudBLProviderTests
{
	public class BasicTests
	{
		private Mock<ITicketRepository> _ticketRepository;
		public BasicTests()
		{
			AutoMapperHelper.Configure();
		}
		private TicketCrudBLProvider InitialiseContructor()
		{
			return new TicketCrudBLProvider(_ticketRepository.Object);
		}

		[Fact]
		public void SmokeTest()
		{
			Assert.True(true);
		}

		[Fact]
		public void TicketBlConstructorInitialised()
		{
			_ticketRepository = new Mock<ITicketRepository>();
			TicketCrudBLProvider sut = InitialiseContructor();
			Assert.IsAssignableFrom<ICrudBLProvider<TicketModel>>(sut);
		}

		[Fact]
		public async void GetReturnsEnumerableOfTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();

			var retVal = new List<Ticket>
			{
				new Ticket()
				{
					Content= "MyContent_1",
					PersonId = 1
				},
				new Ticket()
				{
					Content= "MyContent_2",
					PersonId = 2
				}
			};
			_ticketRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Ticket>));

			TicketCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.IsAssignableFrom<IEnumerable<TicketModel>>(result);
			Assert.Equal(2, result.Count());

		}

		[Fact]
		public async void GetReturnsValidTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();

			var retVal = new List<Ticket>
			{
				new Ticket()
				{
					Content= "MyContent_1",
					PersonId = 1
				},
				new Ticket()
				{
					Content= "MyContent_2",
					PersonId = 2
				}
			};
			_ticketRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Ticket>));

			TicketCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.Equal("MyContent_1", result.FirstOrDefault().Content);

		}

		[Fact]
		public async void GetByIdReturnsTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();
			_ticketRepository.Setup(s => s.FindById(2))
				.Returns(Task.FromResult(
					new Ticket()
					{
						Content = "MyContent_2",
						PersonId = 2
					}));

			TicketCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get(2);

			Assert.Equal("MyContent_2", result.Content);

		}

		[Fact]
		public async void UpdateTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();
			_ticketRepository.Setup(s => s.Update(It.IsAny<Ticket>())).Returns(Task.FromResult(true));

			var ticketModel = new TicketModel()
			{
				Content = "MyContent_1",
				PersonId = 1
			};
			TicketCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Put(1, ticketModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of update

		[Fact]
		public async void AddTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();
			_ticketRepository.Setup(s => s.Add(It.IsAny<Ticket>())).Returns(Task.FromResult(true));

			var ticketModel = new TicketModel()
			{
				Content = "MyContent_1",
				PersonId = 1
			};
			TicketCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Create(ticketModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of add

		[Fact]
		public async void DeleteTicketModel()
		{
			_ticketRepository = new Mock<ITicketRepository>();
			_ticketRepository.Setup(s => s.Remove(It.IsAny<Ticket>())).Returns(Task.FromResult(true));

			TicketCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Delete(1);

			Assert.True(result);
		}
	}
}
