using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly ICrudBLProvider<TicketModel> _crudBlProvider;

		public TicketController(ICrudBLProvider<TicketModel> crudBlProvider)
		{
			_crudBlProvider = crudBlProvider;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var model = _crudBlProvider.Get();
				return Ok(model);
			}catch(Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
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
