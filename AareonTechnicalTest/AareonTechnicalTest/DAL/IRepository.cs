using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public interface IRepository<T>
	{
		Task<IEnumerable<T>> Find();
		Task<T> FindById(int id);
		Task<bool> Add(T entity);
		Task<bool> Update(T entity);
		Task<bool> Delete(int id);
	}
}
