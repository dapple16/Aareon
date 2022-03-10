using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.BL
{
	public class PersonCrudBLProvider : BaseCrudBLProvider<PersonModel, Person>
	{
		public PersonCrudBLProvider(IPersonRepository personRepository)
			: base(personRepository)
		{
		}
	}
}
