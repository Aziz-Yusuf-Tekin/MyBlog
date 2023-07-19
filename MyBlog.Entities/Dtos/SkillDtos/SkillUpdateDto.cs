using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos.SkillDtos
{
	public class SkillUpdateDto : DtoGetBase
	{
		[Required]
		public int Id { get; set; }

		[DisplayName("Yeteneğiniz")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		public string Name { get; set; }

		[DisplayName("Yeteneğinizin yüzdelik olarak (%) seviyesi")]
		[Required(ErrorMessage = "{0} boş geçilmemelidir.")]
		[MaxLength(3, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
		public int Level { get; set; }
	}
}
