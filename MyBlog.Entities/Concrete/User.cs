using MyBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Concrete
{
	public class User : EntityBase, IEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string About { get; set; }
		public string Age { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Adress { get; set; }
		public string Language { get; set; }
		public string Picture { get; set; }

		public ICollection<Education> Educations { get; set; }
		public ICollection<Experience> Experiences { get; set; }
		public ICollection<Reference> References { get; set; }
		public ICollection<Skill> Skills { get; set; }
	}
}
