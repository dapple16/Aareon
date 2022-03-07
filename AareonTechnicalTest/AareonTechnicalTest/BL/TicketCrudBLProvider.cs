using AareonTechnicalTest.BL.Models;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public class TicketCrudBLProvider : ICrudBLProvider<TicketModel>
	{
		public async Task<bool> Create(TicketModel model)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> Delete(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<TicketModel> Get()
		{			
			throw new System.NotImplementedException();
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
