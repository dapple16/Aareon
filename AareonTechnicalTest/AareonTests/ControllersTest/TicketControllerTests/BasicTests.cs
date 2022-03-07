using Xunit;

namespace AareonTests.ControllersTest.TicketControllerTests
{
	public class BasicTests
	{
		[Fact]
		public void SmokeTest()
		{
			Assert.True(true);
		}

		[Fact]
		public void TicketController_CanInitialise()
		{
			var ticketController = new TicketController();

			Assert.NotNull(ticketController);
		}
	}
}
