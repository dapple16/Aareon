using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.BL
{
	public class PersonCrudBLProvider : BaseCrudBLProvider<PersonModel, Person>
	{
		public PersonCrudBLProvider(IPersonRepository personRepository)
		{
			Repository = personRepository;
		}
	}


	public class AuditCrudBLProvider : BaseReadOnlyCrudBLProvider<AuditModel, Audit>
	{
		public AuditCrudBLProvider(IAuditRepository auditRepository)
		{
			Repository = (IRepository<Audit>)auditRepository;
		}
	}
}
