using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public interface IReadOnlyCrudBLProvider<TModel>
	{
		Task<IEnumerable<TModel>> Get();
		Task<TModel> Get(int id);
	}
}