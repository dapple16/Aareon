using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public interface IRepository<TEntity>
	{
		Task<IEnumerable<TEntity>> Find();
		Task<TEntity> FindById(int id);
		Task<bool> Add(TEntity entity);
		Task<bool> Update(TEntity entity);
		Task<bool> Remove(TEntity entity);
	}
}
