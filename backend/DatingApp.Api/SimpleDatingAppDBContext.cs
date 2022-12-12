using DatingApp.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api
{
	public class SimpleDatingAppDBContext : DbContext
	{
		public SimpleDatingAppDBContext(DbContextOptions<SimpleDatingAppDBContext> contextOptions)
		: base(contextOptions) { }

		public SimpleDatingAppDBContext()
		{
		}

		public DbSet<AppUser> appUsers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}