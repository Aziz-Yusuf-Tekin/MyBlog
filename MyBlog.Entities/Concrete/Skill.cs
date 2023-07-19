using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
	public class Skill : EntityBase, IEntity
	{
		public string Name { get; set; }
		public int Level { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
