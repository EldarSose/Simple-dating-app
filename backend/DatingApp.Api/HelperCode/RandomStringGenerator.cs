using System.Text;

namespace DatingApp.Api.HelperCode
{
	public class RandomStringGenerator
	{
		public static string RandomString(int length)
		{
			const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
			var builder = new StringBuilder();

			for (var i = 0; i < length; i++)
			{
				var c = pool[Random.Shared.Next(0, pool.Length)];
				builder.Append(c);
			}
			return builder.ToString();
		}
	}
}
