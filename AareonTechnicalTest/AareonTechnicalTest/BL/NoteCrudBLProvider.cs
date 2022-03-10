using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.BL
{
	public class NoteCrudBLProvider : BaseCrudBLProvider<NoteModel, Note>
	{
		public NoteCrudBLProvider(INoteRepository noteRepository)
		{
			Repository = noteRepository;
		}
	}
}