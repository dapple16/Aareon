using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{	public interface ICrudBLProvider<T>
	{
		Task<T> Get();
		Task<T> Get(int id);
		Task<bool> Put(int id, T model);
		Task<bool> Create(T model);
		Task<bool> Delete(int id);
	}
}
