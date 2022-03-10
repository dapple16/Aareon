using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public abstract class BaseReadOnlyCrudBLProvider<TModel, TEntity> : IReadOnlyCrudBLProvider<TModel>
	{
		private IReadOnlyRepository<TEntity> _repository;

		public BaseReadOnlyCrudBLProvider(IReadOnlyRepository<TEntity> repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<TModel>> Get()
		{
			var data = await _repository.Find();
			var value = data.Select(s => AutoMapperHelper.Map<TEntity, TModel>(s));
			return value;
		}

		public async Task<TModel> Get(int id)
		{
			var data = await _repository.FindById(id);
			var value = AutoMapperHelper.Map<TEntity, TModel>(data);
			return value;
		}
	}
}