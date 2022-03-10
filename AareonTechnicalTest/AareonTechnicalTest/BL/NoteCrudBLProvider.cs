using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public class NoteCrudBLProvider : BaseCrudBLProvider<NoteModel, Note>
	{
		private readonly ITicketRepository _ticketRepository;
		private readonly IPersonRepository _personRepository;

		public NoteCrudBLProvider(INoteRepository noteRepository, ITicketRepository ticketRepository, IPersonRepository personRepository)
		{
			Repository = noteRepository;
			_ticketRepository = ticketRepository;
			_personRepository = personRepository;
		}

		public override async Task<bool> Delete(int id)
		{
			var existingRecord = await Repository.FindById(id);
			var ticket = await _ticketRepository.FindById(existingRecord.TicketId);
			var person = await _personRepository.FindById(ticket.PersonId);

			if (person.IsAdmin)
			{
				var value = await Repository.Remove(existingRecord);
				return value;
			}
			return false;
		}
	}
}