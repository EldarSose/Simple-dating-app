using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DatingApp.Api.HelperCode
{
	public class UserExists
	{
		public static async Task<bool> CheckUserExists(string username, SimpleDatingAppDBContext dBContext)
		{
			return await dBContext.appUsers.AnyAsync(x => x.username== username);
		}
	}
}
