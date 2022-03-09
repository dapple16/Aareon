using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public class BaseCrudBLProvider<TModel, TDao> : ICrudBLProvider<TModel>
	{
		protected IRepository<TDao> Repository;

		public async Task<IEnumerable<TModel>> Get()
		{
			var data = await Repository.Find();
			var value = data.Select(s => AutoMapperHelper.Map<TDao, TModel>(s));
			return value;
		}

		public Task<TModel> Get(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Put(int id, TModel model)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> Create(TModel model)
		{
			var result = await Repository.Add(AutoMapperHelper.Map<TModel, TDao>(model));
			return result;
		}

		public Task<bool> Delete(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
