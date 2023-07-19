using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos.ExperienceDtos
{
	public class ExperienceAddDto
	{
		[DisplayName("Başlama Tarihi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string StartDate { get; set; }

		[DisplayName("Çıkış Tarihi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string EndDate { get; set; }

		[DisplayName("Görevi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Position { get; set; }

		[DisplayName("Çalıştığı Yer")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Place { get; set; }

		[DisplayName("İş Açıklaması")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Comment { get; set; }

		public bool IsActive { get; set; }
	}
}
