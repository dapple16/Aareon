using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;
using System.Collections.Generic;
using Xunit;

namespace AareonTests.DALTests
{
	public class TicketRepositoryTests
	{
		[Fact]
		public async void test()
		{
			var repo = new TicketRepository();
			var result = await repo.FindById(1);

			Assert.IsAssignableFrom<IEnumerable<Ticket>>(result);
		}
	}
}
