using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class TicketRepository : ITicketRepository
	{
		DbContextOptions<ApplicationContext> options = new DbContextOptions<ApplicationContext>();
		public async Task<IEnumerable<Ticket>> Find()
		{
			IEnumerable<Ticket> tickets = Enumerable.Empty<Ticket>();

			using (var context = new ApplicationContext(options))
			{
				var result = await context.Tickets.ToListAsync();
				tickets = result;
			}

			return tickets;
		}

		public async Task<Ticket> FindById(int id)
		{
			Ticket ticket = null;
			using (var context = new ApplicationContext(options))
			{
				ticket = await context.Tickets.FindAsync(id);
			}

			return ticket;
		}
	}
}
