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
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(25);
			builder.Property(x => x.Surname).IsRequired();
			builder.Property(x => x.Surname).HasMaxLength(15);
			builder.Property(x => x.Adress).IsRequired();
			builder.Property(x => x.Adress).HasMaxLength(35);
			builder.Property(x => x.Language).IsRequired();
			builder.Property(x => x.Language).HasMaxLength(20);
			builder.Property(x => x.Age).IsRequired();
			builder.Property(x => x.Age).HasMaxLength(2);
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Email).HasMaxLength(50);
			builder.Property(x => x.PhoneNumber).IsRequired();
			builder.Property(x => x.PhoneNumber).HasMaxLength(15);
			builder.Property(x => x.Picture).IsRequired();
			builder.Property(x => x.Picture).HasMaxLength(250);
			builder.Property(x => x.About).IsRequired();
			builder.Property(x => x.About).HasMaxLength(1000);
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.ToTable("Users");

			builder.HasData(new User
			{
				Id = 1,
				Name = "Aziz Yusuf Tekin",
				Surname = "Tekin",
				About = "Karabük Üniversitesi 5. Sınıf öğrencisiyim. İstanbulda yaşıyorum.",
				Age = "22",
				Email = "azizyusuftekin1116@gmail.com",
				PhoneNumber = "+905454284089",
				Adress = "İstanbul/Başakşehir",
				Language = "Türkçe,İngilizce",
				Picture = "azizyusuftekin.jpg",
				IsDeleted = false,
				IsActive = true
			});
		}
	}
}
