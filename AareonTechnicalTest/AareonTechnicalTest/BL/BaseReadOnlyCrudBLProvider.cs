using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public abstract class BaseReadOnlyCrudBLProvider<TModel, TEntity> : IReadOnlyCrudBLProvider<TModel>
	{
		protected IRepository<TEntity> Repository;

		public async Task<IEnumerable<TModel>> Get()
		{
			var data = await Repository.Find();
			var value = data.Select(s => AutoMapperHelper.Map<TEntity, TModel>(s));
			return value;
		}

		public async Task<TModel> Get(int id)
		{
			var data = await Repository.FindById(id);
			var value = AutoMapperHelper.Map<TEntity, TModel>(data);
			return value;
		}
	}
}