using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WindowsFormsApp1
{
	public class PeopleContext : DbContext
	{
		public PeopleContext()
			: base("DbConnection")
		{ }
		public DbSet<Person> People { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Говорим EF, что сущность Person может иметь много Phones. 
			modelBuilder.Entity<Person>().HasMany(p => p.Phones);
		}
	}
}
