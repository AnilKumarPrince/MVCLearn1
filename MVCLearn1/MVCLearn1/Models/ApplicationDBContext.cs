using Microsoft.EntityFrameworkCore;

namespace MVCLearn1.Models
{
	public class ApplicationDBContext1 : DbContext
	{
		
		public ApplicationDBContext1(DbContextOptions<ApplicationDBContext1> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
