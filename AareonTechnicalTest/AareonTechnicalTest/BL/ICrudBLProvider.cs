using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{	public interface ICrudBLProvider<TModel>
	{
		Task<IEnumerable<TModel>> Get();
		Task<TModel> Get(int id);
		Task<bool> Put(int id, TModel model);
		Task<bool> Create(TModel model);
		Task<bool> Delete(int id);
	}
}