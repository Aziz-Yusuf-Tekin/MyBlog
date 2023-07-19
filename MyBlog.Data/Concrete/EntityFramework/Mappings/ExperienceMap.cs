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
	public class ExperienceMap : IEntityTypeConfiguration<Experience>
	{
		public void Configure(EntityTypeBuilder<Experience> builder)
		{
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Position).IsRequired();
			builder.Property(x => x.Position).HasMaxLength(100);
			builder.Property(x => x.Place).IsRequired();
			builder.Property(x => x.Place).HasMaxLength(100);
			builder.Property(x => x.Comment).IsRequired();
			builder.Property(x => x.Comment).HasMaxLength(1000);
			builder.Property(x => x.StartDate).IsRequired();
			builder.Property(x => x.StartDate).HasMaxLength(20);
			builder.Property(x => x.EndDate).IsRequired();
			builder.Property(x => x.EndDate).HasMaxLength(20);
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.HasOne<User>(x => x.User).WithMany(u => u.Experiences).HasForeignKey(x => x.UserId);
			builder.ToTable("Experiences");

			builder.HasData(new Experience
			{
				Id = 1,
				UserId = 1,
				StartDate = "temmuz 2023",
				EndDate = "ağustos 2023",
				Place = "HiperMedya",
				Position = "Stajyer",
				Comment = "Okulumun zorunlu kıldığı ya stajımı HiperMedya firmasında yaptım.",
				IsDeleted= false,
				IsActive= true
			});
		}
	}
}
