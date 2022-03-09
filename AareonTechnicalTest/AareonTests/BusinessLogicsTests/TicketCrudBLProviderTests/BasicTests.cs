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

namespace AareonTests.BusinessLogicsTests.TicketBusinessLogicTests
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

			Assert.Equal("MyContent", result.FirstOrDefault().Content);

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
	}
}
