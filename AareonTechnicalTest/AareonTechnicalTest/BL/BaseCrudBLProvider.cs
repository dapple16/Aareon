using AareonTechnicalTest.Helper;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public abstract class BaseCrudBLProvider<TModel, TEntity> : BaseReadOnlyCrudBLProvider<TModel, TEntity>, ICrudBLProvider<TModel>
	{
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

		public virtual async Task<bool> Delete(int id)
		{
			var existingRecord = await Repository.FindById(id); 
			var value = await Repository.Remove(existingRecord);
			return value;
		}
	}
}