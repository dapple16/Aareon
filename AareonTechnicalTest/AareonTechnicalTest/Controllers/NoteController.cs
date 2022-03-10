using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class NoteController : BaseController<NoteModel>
	{
		public NoteController(ICrudBLProvider<NoteModel> crudBLProvider) : base(crudBLProvider)
		{ }
	}
}
