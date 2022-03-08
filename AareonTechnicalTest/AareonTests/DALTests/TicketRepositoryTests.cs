using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;
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
			_ticketRepo = new TicketRepository();
			_personRepo = new PersonRepository();
		}

		[Fact]
		public async void CanAddNewItemToTicketRepository()
		{
			var person = new Person
			{
				Forename = "Forename",
				Surname = "Surname",
				IsAdmin = true,
			};

			var personResult = await _personRepo.Add(person);


			var ticket = new Ticket
			{
				PersonId = 1,
				Content = "My Content"
			};

			var ticketResult = _ticketRepo.Add(ticket);

			Assert.IsAssignableFrom<bool>(ticketResult);
		}

		[Fact]
		public async void test()
		{
			var result = await _ticketRepo.FindById(1);

			Assert.IsAssignableFrom<IEnumerable<Ticket>>(result);
		}
	}
}
