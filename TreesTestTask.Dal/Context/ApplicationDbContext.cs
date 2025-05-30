using Microsoft.EntityFrameworkCore;
using TreesTestTask.Dal.Contracts.Entities;

namespace TreesTestTask.Migrations.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.Migrate();
		}

		public DbSet<Node> Nodes { get; set; }
		public DbSet<JournalRecord> JournalRecords { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Node>()
			            .HasOne(n => n.Parent)
			            .WithMany(n => n.Children)
			            .HasForeignKey(n => n.ParentId)
			            .OnDelete(DeleteBehavior.Restrict);
		}
	}
}