using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AareonTechnicalTest.DAL
{
	public class BaseRepository
	{
		protected DbContextOptions<ApplicationContext> options = new DbContextOptions<ApplicationContext>();
		protected async void SaveAudit(string audit)
		{
			using (var context = new ApplicationContext(options))
			{
				var _ = await context.Audits.AddAsync(new Audit { Log = audit });
				Console.Out.WriteLine(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
			}
		}
	}
}
