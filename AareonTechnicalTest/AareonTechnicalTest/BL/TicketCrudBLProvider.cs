using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using AareonTechnicalTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public class TicketCrudBLProvider : ICrudBLProvider<TicketModel>
	{
		private readonly ITicketRepository ticketRepository;

		public TicketCrudBLProvider(ITicketRepository _ticketRepository)
		{
			ticketRepository = _ticketRepository;
		}
		public async Task<bool> Create(TicketModel model)
		{
			var result = await ticketRepository.Add(AutoMapperHelper.Map<TicketModel, Ticket>(model));
			return result;
		}

		public async Task<bool> Delete(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<TicketModel>> Get()
		{
			var data = await ticketRepository.Find();
			var value = data.Select(s => AutoMapperHelper.Map<Ticket, TicketModel>(s));
			return value;
		}

		public async Task<TicketModel> Get(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> Put(int id, TicketModel model)
		{
			throw new System.NotImplementedException();
		}
    }
}
