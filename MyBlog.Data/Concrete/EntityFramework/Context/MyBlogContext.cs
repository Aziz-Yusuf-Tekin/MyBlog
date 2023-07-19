using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Concrete.EntityFramework.Mappings;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Context
{
	public class MyBlogContext : DbContext
	{
		public DbSet<Education> Educations { get; set; }
		public DbSet<Experience> Experiences{ get; set; }
		public DbSet<Reference> References { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString: @"Server=.;Database=MyBlog;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True; TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EducationMap());
			modelBuilder.ApplyConfiguration(new ExperienceMap());
			modelBuilder.ApplyConfiguration(new ReferenceMap());
			modelBuilder.ApplyConfiguration(new SkillMap());
			modelBuilder.ApplyConfiguration(new UserMap());
		}
	}
}
