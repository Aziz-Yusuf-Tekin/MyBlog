using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete.EntityFramework.Mappings
{
	public class SkillMap : IEntityTypeConfiguration<Skill>
	{
		public void Configure(EntityTypeBuilder<Skill> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x=>x.Name).HasMaxLength(15);
			builder.Property(x=>x.Level).IsRequired();
			builder.Property(x=>x.Level).HasMaxLength(3);
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.HasOne<User>(x => x.User).WithMany(u => u.Skills).HasForeignKey(x => x.UserId);
			builder.ToTable("Skills");

			builder.HasData(new Skill
			{
				Id = 1,
				UserId = 1,
				Name = "Asp.net Core",
				Level = 70,
				IsDeleted = false,
				IsActive = true
			});
		}
	}
}
