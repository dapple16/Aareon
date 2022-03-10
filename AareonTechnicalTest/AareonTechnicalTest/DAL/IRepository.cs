using System.Threading.Tasks;

namespace AareonTechnicalTest.DAL
{
	public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
	{
		Task<bool> Add(TEntity entity);
		Task<bool> Update(TEntity entity);
		Task<bool> Remove(TEntity entity);
	}
}
