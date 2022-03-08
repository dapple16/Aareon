using AareonTechnicalTest.BL;
using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.DAL;
using Moq;
using Xunit;

namespace AareonTests.BusinessLogicsTests.TicketBusinessLogicTests
{
	public class BasicTests
	{
		[Fact]
		public void SmokeTest()
		{
			Assert.True(true);
		}

		[Fact]
		public void TicketBlConstructorInitialised()
		{
			var sut = new TicketCrudBLProvider(Mock.Of<ITicketRepository>());
			Assert.IsAssignableFrom<ICrudBLProvider<TicketModel>>(sut);
		}
	}
}
