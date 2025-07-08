using System.Threading.Tasks;

namespace IntegrationTests
{
	internal static class Program
	{
		private static async Task Main()
		{
			await Tests.RunAllApiIntegrationTests();
		}
	}
}