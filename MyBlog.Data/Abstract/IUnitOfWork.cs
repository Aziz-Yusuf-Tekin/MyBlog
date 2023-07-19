using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Abstract
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IEducationRepository Educations { get; }
		IExperienceRepository Experiences { get; }
		IReferenceRepository References { get; }
		ISkillRepository Skills { get; }
		IUserRepository Users { get; }
		Task<int> SaveAsync();
	}
}
