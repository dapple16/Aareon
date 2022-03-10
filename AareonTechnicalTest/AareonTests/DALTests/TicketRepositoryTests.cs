using AareonTechnicalTest;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace AareonTests.DALTests
{
	public class TicketRepositoryTests
	{
		private TicketRepository _ticketRepo;
		private PersonRepository _personRepo;

		public TicketRepositoryTests()
		{
			// TODO: The application context needs to setup to take Icontext as dependency then the test context can be injected for the test purpose.
			var blah = new Startup(Mock.Of<IConfiguration>());
			blah.ConfigureServices(new ServiceCollection());

			_ticketRepo = new TicketRepository();
			_personRepo = new PersonRepository();
		}

		//[Fact]
		public async void CanAddNewItemToTicketRepository()
		{
			//var person = new Person
			//{
			//	Forename = "Forename",
			//	Surname = "Surname",
			//	IsAdmin = true,
			//};

			//var personResult = await _personRepo.Add(person);


			var ticket = new Ticket
			{
				PersonId = 1,
				Content = "My Content"
			};

			var ticketResult = _ticketRepo.Add(ticket);


			var result = await _ticketRepo.FindById(1);

			Assert.Equal(1, result.Id);
		}

		//[Fact]
		public async void test()
		{
			var result = await _ticketRepo.FindById(1);

			Assert.IsAssignableFrom<IEnumerable<Ticket>>(result);
		}
	}
}