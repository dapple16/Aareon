using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public interface IReadOnlyRepository<TEntity>
	{
		Task<IEnumerable<TEntity>> Find();
		Task<TEntity> FindById(int id);
	}
}
