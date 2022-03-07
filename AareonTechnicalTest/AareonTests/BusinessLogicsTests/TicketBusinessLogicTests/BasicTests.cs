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
			var sut = new TicketBL();
			Assert.IsAssignableFrom<ICrudBLProvider>(sut);
		}
	}
}
