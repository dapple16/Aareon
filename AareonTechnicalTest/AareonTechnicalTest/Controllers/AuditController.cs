using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AareonTechnicalTest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuditController : BaseReadOnlyController<AuditModel>
	{
		public AuditController(IReadOnlyCrudBLProvider<AuditModel> crudBLProvider) : base(crudBLProvider)
		{ }
	}
}