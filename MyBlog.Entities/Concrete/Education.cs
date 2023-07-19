using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
	public class Education : EntityBase, IEntity
	{
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Level { get; set; }
		public string Department { get; set; }
		public string School { get; set; }
		public string Comment { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
