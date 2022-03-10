using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class AuditRepository : BaseRepository, IAuditRepository
	{
		public async Task<IEnumerable<Audit>> Find()
		{
			IEnumerable<Audit> audits = Enumerable.Empty<Audit>();

			using (var context = new ApplicationContext(options))
			{
				audits = await context.Audits.ToListAsync();
			}

			return audits;
		}

		public async Task<Audit> FindById(int id)
		{
			Audit audit = null;
			using (var context = new ApplicationContext(options))
			{
				audit = await context.Audits.FindAsync(id);
			}
			return audit;
		}
	}
}
