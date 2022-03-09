using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public class BaseCrudBLProvider<TModel, TEntity> : ICrudBLProvider<TModel>
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

		public async Task<bool> Put(int id, TModel model)
		{
			var existingRecord = await Repository.FindById(id);
			var toBeSavedRecord = AutoMapperHelper.Map(model, existingRecord);
			var value = await Repository.Update(toBeSavedRecord);
			return value;
		}

		public async Task<bool> Create(TModel model)
		{
			var result = await Repository.Add(AutoMapperHelper.Map<TModel, TEntity>(model));
			return result;
		}

		public async Task<bool> Delete(int id)
		{
			var existingRecord = await Repository.FindById(id); 
			var value = await Repository.Remove(existingRecord);
			return value;
		}
	}
}
