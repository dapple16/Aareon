using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PersonController : BaseController<PersonModel>
	{
		public PersonController(ICrudBLProvider<PersonModel> crudBLProvider) : base(crudBLProvider)
		{ }
	}
}