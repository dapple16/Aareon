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

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok();
		}

		[HttpPut("update/{id}")]
		public IActionResult Put(int id, [FromBody] TicketModel model)
		{
			return Ok();
		}

		[HttpPost("Create")]
		public IActionResult Create([FromBody]TicketModel model)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok();
		}
	}
}
