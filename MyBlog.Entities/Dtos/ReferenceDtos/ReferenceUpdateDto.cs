using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos.ReferanceDtos
{
	public class ReferenceUpdateDto
	{
		[Required]
		public int Id { get; set; }

		[DisplayName("Referansın Adı")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Name { get; set; }

		[DisplayName("Referansın Soyadı")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Surname { get; set; }

		[DisplayName("Referansın Statüsü")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Status { get; set; }

		[DisplayName("Referansın Resmi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Picture { get; set; }

		[DisplayName("Referansın Bilgileri")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		[MinLength(4, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
		public string Opinion { get; set; }

		public bool IsActive { get; set; }
	}
}
