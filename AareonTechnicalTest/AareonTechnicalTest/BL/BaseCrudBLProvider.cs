using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public abstract class BaseCrudBLProvider<TModel, TEntity> : BaseReadOnlyCrudBLProvider<TModel, TEntity>, ICrudBLProvider<TModel>
	{
		private IRepository<TEntity> _repository;
		public BaseCrudBLProvider(IRepository<TEntity> repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<bool> Put(int id, TModel model)
		{
			var existingRecord = await _repository.FindById(id);
			var toBeSavedRecord = AutoMapperHelper.Map(model, existingRecord);
			var value = await _repository.Update(toBeSavedRecord);
			return value;
		}

		public async Task<bool> Create(TModel model)
		{
			var result = await _repository.Add(AutoMapperHelper.Map<TModel, TEntity>(model));
			return result;
		}

		public virtual async Task<bool> Delete(int id)
		{
			var existingRecord = await _repository.FindById(id); 
			var value = await _repository.Remove(existingRecord);
			return value;
		}
	}
}