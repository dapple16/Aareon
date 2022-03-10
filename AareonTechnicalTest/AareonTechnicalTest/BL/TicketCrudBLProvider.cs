using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.BL
{
	public class TicketCrudBLProvider : BaseCrudBLProvider<TicketModel, Ticket>
	{
		public TicketCrudBLProvider(ITicketRepository ticketRepository)
			: base(ticketRepository)
		{
		}
	}
}