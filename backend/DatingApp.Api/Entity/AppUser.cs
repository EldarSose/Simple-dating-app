using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Entity
{
	public class AppUser
	{
		[Key]
		public int AppUserId { get; set; }
		public string username { get; set; }
		public byte[] passwordHash { get; set; }
		public byte[] passwordSalt { get; set; }
	}
}
