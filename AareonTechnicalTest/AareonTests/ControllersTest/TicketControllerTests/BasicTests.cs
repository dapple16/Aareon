using AareonTechnicalTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AareonTests.ControllersTest.TicketControllerTests
{
	public class BasicTests
	{
		[Fact]
		public void CanInitialise()
		{
			var sut = new TicketController();

			Assert.NotNull(sut);
		}

		[Fact]
		public void CanGet()
		{
			var sut = new TicketController();
			var result = sut.Get();

			Assert.IsType<IActionResult>(result);
		}
	}
}
