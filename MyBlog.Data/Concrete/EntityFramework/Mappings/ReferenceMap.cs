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
	public class ReferenceMap : IEntityTypeConfiguration<Reference>
	{
		public void Configure(EntityTypeBuilder<Reference> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(30);
			builder.Property(x => x.Surname).IsRequired();
			builder.Property(x => x.Surname).HasMaxLength(20);
			builder.Property(x => x.Status).IsRequired();
			builder.Property(x => x.Status).HasMaxLength(20);
			builder.Property(x => x.Opinion).IsRequired();
			builder.Property(x => x.Opinion).HasMaxLength(1000);
			builder.Property(x => x.Picture).IsRequired();
			builder.Property(x => x.Picture).HasMaxLength(250);
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.HasOne<User>(x => x.User).WithMany(u => u.References).HasForeignKey(x => x.UserId);
			builder.ToTable("References");

			builder.HasData(new Reference
			{
				Id = 1,
				UserId = 1,
				Name = "Özkan",
				Surname = "Tekin",
				Picture = "ozkantekin.jpg",
				Status = "Yazılım Uzmanı",
				Opinion = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.",
				IsDeleted = false,
				IsActive = true
			});
		}
	}
}
