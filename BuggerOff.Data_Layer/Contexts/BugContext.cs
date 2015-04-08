using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Data_Layer.Models;
using System.Data.Common;

namespace Data_Layer.Contexts
{
	public class BugContext : DbContext
	{
		public DbSet<Bug> Bugs { get; set; }

		protected override void OnConfiguring(DbContextOptions builder)
		{
			builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BugTracker;Trusted_Connection=True;MultipleActiveResultSets=True");
		}
	}
}