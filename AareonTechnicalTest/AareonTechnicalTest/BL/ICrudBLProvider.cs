using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{
	public interface ICrudBLProvider<TModel> : IReadOnlyCrudBLProvider<TModel>
	{
		Task<bool> Put(int id, TModel model);
		Task<bool> Create(TModel model);
		Task<bool> Delete(int id);
	}
}