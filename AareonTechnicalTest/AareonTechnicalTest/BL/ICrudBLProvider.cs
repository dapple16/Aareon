namespace AareonTechnicalTest.BL
{	public interface ICrudBLProvider<T>
	{
		T Get();
		bool Put(T model);
		bool Create(T model);
		bool Delete(int id);
	}
}
