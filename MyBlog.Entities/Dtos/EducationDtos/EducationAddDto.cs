using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos.EducationDtos
{
	public class EducationAddDto
	{
		[DisplayName("Başlama Tarihi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string StartDate { get; set; }

		[DisplayName("Bitirme Tarihi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string EndDate { get; set; }

		[DisplayName("Eğitim Seviyesi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Level { get; set; }

		[DisplayName("Okuduğu Bölüm")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Department { get; set; }

		[DisplayName("Eğitim Aldığı Okul")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string School { get; set; }

		[DisplayName("Eğitim Açıklaması")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Comment { get; set; }

		public bool IsActive { get; set; }
	}
}
