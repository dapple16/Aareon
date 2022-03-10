using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class NoteRepository : INoteRepository
	{
		DbContextOptions<ApplicationContext> options = new DbContextOptions<ApplicationContext>();
		public async Task<IEnumerable<Note>> Find()
		{
			IEnumerable<Note> note = Enumerable.Empty<Note>();

			using (var context = new ApplicationContext(options))
			{
				note = await context.Notes.ToListAsync();
			}

			return note;
		}

		public async Task<Note> FindById(int id)
		{
			Note Note = null;
			using (var context = new ApplicationContext(options))
			{
				Note = await context.Notes.FindAsync(id);
			}

			return Note;
		}

		public async Task<bool> Add(Note Note)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = await context.Notes.AddAsync(Note);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}

		public async Task<bool> Update(Note Note)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Notes.Update(Note);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}

		public async Task<bool> Remove(Note Note)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Notes.Remove(Note);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}
	}
}
