using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TicketController : BaseController<TicketModel>
	{
		public TicketController(ICrudBLProvider<TicketModel> crudBLProvider) : base(crudBLProvider)
		{ }
	}
}