using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
		public async Task<IActionResult> Get()
		{
			try
			{
				var model = await _crudBlProvider.Get();
				return Ok(model);
			}catch(Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var model = await _crudBlProvider.Get(id);
				return Ok(model);
			}
			catch (Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] TicketModel model)
		{
			try
			{
				var result = await _crudBlProvider.Put(id, model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody]TicketModel model)
		{
			try
			{
				var result = await _crudBlProvider.Create(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var result = await _crudBlProvider.Delete(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}
	}
}
