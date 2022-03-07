using System.Threading.Tasks;

namespace AareonTechnicalTest.BL
{	public interface ICrudBLProvider<T>
	{
		Task<T> Get();
		Task<T> Get(int id);
		bool Put(int id, T model);
		bool Create(T model);
		bool Delete(int id);
	}
}
