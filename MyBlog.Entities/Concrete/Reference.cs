using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
	public class Reference : EntityBase, IEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Picture { get; set; }
		public string Status { get; set; }
		public string Opinion { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
