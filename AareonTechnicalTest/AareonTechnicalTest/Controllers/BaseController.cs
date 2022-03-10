using AareonTechnicalTest.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public abstract class BaseController<T> : ControllerBase
	{
		private readonly ICrudBLProvider<T> _crudBlProvider;

		public BaseController(ICrudBLProvider<T> crudBlProvider)
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
			}catch (Exception)
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
			catch (Exception)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] T model)
		{
			try
			{
				var result = await _crudBlProvider.Put(id, model);
				return Ok(result);
			}
			catch (Exception)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody]T model)
		{
			try
			{
				var result = await _crudBlProvider.Create(model);
				return Ok(result);
			}
			catch (Exception)
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
			catch (Exception)
			{
				// Log the exception on the logger.
			}
			return NoContent();
		}
	}
}
