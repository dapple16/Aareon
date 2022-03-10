using AareonTechnicalTest.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public abstract class BaseReadOnlyController<T> : ControllerBase
	{
		private readonly IReadOnlyCrudBLProvider<T> _crudBlProvider;

		public BaseReadOnlyController(IReadOnlyCrudBLProvider<T> crudBlProvider)
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
			} catch (Exception)
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
	}
}
