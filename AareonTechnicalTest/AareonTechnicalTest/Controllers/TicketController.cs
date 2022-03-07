using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly ICrudBLProvider<TicketModel> crudBlProvider;

		public TicketController(ICrudBLProvider<TicketModel> crudBlProvider)
		{
			this.crudBlProvider = crudBlProvider;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}
	}
}
