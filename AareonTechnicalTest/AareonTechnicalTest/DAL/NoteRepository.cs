using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class NoteRepository : BaseRepository, INoteRepository
	{
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
			Note note = null;
			using (var context = new ApplicationContext(options))
			{
				note = await context.Notes.FindAsync(id);
			}

			return note;
		}

		public async Task<bool> Add(Note Note)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = await context.Notes.AddAsync(Note);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
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
				SaveAudit(context.ChangeTracker.DebugView.LongView);
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
				context.ChangeTracker.DetectChanges();
				var _ = context.Notes.Remove(Note);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}
	}
}
