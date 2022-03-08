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


		public async Task<bool> Add(Ticket ticket)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var temp = await context.Tickets.AddAsync(ticket);
				var temp2 = await context.SaveChangesAsync();
				result = true;
			}

			return result;
		}
	}

	public class PersonRepository : IPersonRepository
	{
		DbContextOptions<ApplicationContext> options = new DbContextOptions<ApplicationContext>();
		public async Task<IEnumerable<Person>> Find()
		{
			IEnumerable<Person> results = Enumerable.Empty<Person>();

			using (var context = new ApplicationContext(options))
			{
				var temp = await context.Persons.ToListAsync();
				results = temp;
			}

			return results;
		}

		public async Task<Person> FindById(int id)
		{
			Person person = null;
			using (var context = new ApplicationContext(options))
			{
				person = await context.Persons.FindAsync(id);
			}

			return person;
		}

		public async Task<bool> Add(Person person)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var temp = await context.Persons.AddAsync(person);
				var temp2 = await context.SaveChangesAsync();
				result = true;
			}

			return result;
		}
	}
}
