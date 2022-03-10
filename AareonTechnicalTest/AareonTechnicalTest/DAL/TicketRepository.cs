﻿using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public class TicketRepository : BaseRepository, ITicketRepository
	{
		public async Task<IEnumerable<Ticket>> Find()
		{
			IEnumerable<Ticket> tickets = Enumerable.Empty<Ticket>();

			using (var context = new ApplicationContext(options))
			{
				tickets = await context.Tickets.ToListAsync();
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
				var _ = await context.Tickets.AddAsync(ticket);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}

		public async Task<bool> Update(Ticket ticket)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Tickets.Update(ticket);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}

		public async Task<bool> Remove(Ticket ticket)
		{
			var result = false;
			using (var context = new ApplicationContext(options))
			{
				var _ = context.Tickets.Remove(ticket);
				SaveAudit(context.ChangeTracker.DebugView.LongView);
				var state = await context.SaveChangesAsync();
				result = state > 0 ? true : false;
			}

			return result;
		}
	}
}
