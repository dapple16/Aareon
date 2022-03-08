using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;
using System.Collections.Generic;
using Xunit;

namespace AareonTests.DALTests
{
	public class TicketRepositoryTests
	{
		private TicketRepository _repo;

		public TicketRepositoryTests()
		{
			_repo = new TicketRepository();
		}

		[Fact]
		public async void CanAddNewItemToTicketRepository()
		{
			var ticket = new Ticket
			{
				PersonId = 1,
				Content = "My Content"
			};

			var result = await repo.Add(ticket);

			Assert.IsAssignableFrom<bool>(result);
		}

		[Fact]
		public async void test()
		{
			var result = await repo.FindById(1);

			Assert.IsAssignableFrom<IEnumerable<Ticket>>(result);
		}
	}
}
