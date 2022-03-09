using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using AareonTechnicalTest.Helper;
using AareonTechnicalTest.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AareonTests.BusinessLogicsTests.PersonCrudBLProviderTests
{
	public class BasicTests
	{
		private Mock<IPersonRepository> _personRepository;
		public BasicTests()
		{
			AutoMapperHelper.Configure();
		}
		private PersonCrudBLProvider InitialiseContructor()
		{
			return new PersonCrudBLProvider(_personRepository.Object);
		}

		[Fact]
		public void PersonBlConstructorInitialised()
		{
			_personRepository = new Mock<IPersonRepository>();
			PersonCrudBLProvider sut = InitialiseContructor();
			Assert.IsAssignableFrom<ICrudBLProvider<PersonModel>>(sut);
		}

		[Fact]
		public async void GetReturnsEnumerableOfPersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();

			var retVal = new List<Person>
			{
				new Person()
					{
						Forename = "First",
						Surname = "Last",
						IsAdmin = true
					},
				new Person()
					{
						Forename = "First",
						Surname = "Last",
						IsAdmin = true
					}
			};
			_personRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Person>));

			PersonCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.IsAssignableFrom<IEnumerable<PersonModel>>(result);
			Assert.Equal(2, result.Count());

		}

		[Fact]
		public async void GetReturnsValidPersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();

			var retVal = new List<Person>
			{
				new Person()
					{
						Forename = "First",
						Surname = "Last",
						IsAdmin = true
					},
				new Person()
					{
						Forename = "First",
						Surname = "Last",
						IsAdmin = true
					}
			};
			_personRepository.Setup(s => s.Find()).Returns(Task.FromResult(retVal as IEnumerable<Person>));

			PersonCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get();

			Assert.Equal("First", result.FirstOrDefault().Forename);
		}

		[Fact]
		public async void GetByIdReturnsPersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();
			_personRepository.Setup(s => s.FindById(2))
				.Returns(Task.FromResult(
					new Person()
					{
						Forename = "First",
						Surname = "Last",
						IsAdmin = true
					}));

			PersonCrudBLProvider sut = InitialiseContructor();

			var result = await sut.Get(2);

			Assert.Equal("First", result.Forename);

		}

		[Fact]
		public async void UpdatePersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();
			_personRepository.Setup(s => s.Update(It.IsAny<Person>())).Returns(Task.FromResult(true));

			var personModel = new PersonModel()
			{
				Forename = "First",
				Surname = "Last",
				IsAdmin = true
			};
			PersonCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Put(1, personModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of update

		[Fact]
		public async void AddPersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();
			_personRepository.Setup(s => s.Add(It.IsAny<Person>())).Returns(Task.FromResult(true));

			var personModel = new PersonModel()
			{
				Forename = "First",
				Surname = "Last",
				IsAdmin = true
			};
			PersonCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Create(personModel);

			Assert.True(result);
		}

		//TODO: needs more tests on failure path of add

		[Fact]
		public async void DeletePersonModel()
		{
			_personRepository = new Mock<IPersonRepository>();
			_personRepository.Setup(s => s.Remove(It.IsAny<Person>())).Returns(Task.FromResult(true));

			PersonCrudBLProvider sut = InitialiseContructor();
			var result = await sut.Delete(1);

			Assert.True(result);
		}
	}
}
