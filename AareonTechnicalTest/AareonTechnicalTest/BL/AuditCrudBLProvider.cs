using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.BL
{
	public class AuditCrudBLProvider : BaseReadOnlyCrudBLProvider<AuditModel, Audit>
	{
		public AuditCrudBLProvider(IAuditRepository auditRepository)
			: base(auditRepository)
		{
		}
	}
}