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
	public class EducationMap : IEntityTypeConfiguration<Education>
	{
		public void Configure(EntityTypeBuilder<Education> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x =>x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Department).IsRequired();
			builder.Property(x => x.Department).HasMaxLength(100);
			builder.Property(x => x.Level).IsRequired();
			builder.Property(x => x.Level).HasMaxLength(100);
			builder.Property(x => x.School).IsRequired();
			builder.Property(x => x.School).HasMaxLength(100);
			builder.Property(x => x.Comment).IsRequired();
			builder.Property(x => x.Comment).HasMaxLength(1000);
			builder.Property(x => x.StartDate).IsRequired();
			builder.Property(x => x.StartDate).HasMaxLength(20);
			builder.Property(x => x.EndDate).IsRequired();
			builder.Property(x => x.EndDate).HasMaxLength(20);
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.HasOne<User>(x => x.User).WithMany(u => u.Educations).HasForeignKey(x => x.UserId);
			builder.ToTable("Educations");
			builder.HasData(new Education
			{
				Id = 1,
				UserId = 1,
				StartDate = "eylül 2019",
				EndDate = "Devam ediyor",
				Level = "Lisans",
				Department = "Mekatronik Mühendisliği",
				School = "Karabük Üniversitesi",
				Comment = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.",
				IsDeleted = false,
				IsActive = true
			});
		}
	}
}
