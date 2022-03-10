using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

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
	}
}