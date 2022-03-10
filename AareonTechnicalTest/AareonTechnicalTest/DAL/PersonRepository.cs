using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class PersonRepository : BaseRepository, IPersonRepository
	{
		public async Task<IEnumerable<Person>> Find()
		{
			IEnumerable<Person> results = Enumerable.Empty<Person>();

			using (var context = new ApplicationContext(options))
			{
				results = await context.Persons.ToListAsync();
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
				var _ = await context.Persons.AddAsync(person);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}

		public async Task<bool> Update(Person person)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Persons.Update(person);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}


		public async Task<bool> Remove(Person person)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Persons.Remove(person);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}
	}
}