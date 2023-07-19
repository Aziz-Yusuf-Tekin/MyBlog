using MyBlog.Entities.Concrete;
using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Dtos.EducationDtos
{
	public class EducationDto : DtoGetBase
	{
		public Education Education { get; set; }
	}
}
