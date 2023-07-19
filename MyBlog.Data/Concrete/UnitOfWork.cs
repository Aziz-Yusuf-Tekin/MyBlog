using MyBlog.Data.Abstract;
using MyBlog.Data.Concrete.EntityFramework.Context;
using MyBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MyBlogContext _context;
		private EfEducationRepository _educationRepository;
		private EfExperienceRepository _experienceRepository;
		private EfReferenceRepository _referenceRepository;
		private EfSkillRepository _skillRepository;
		private EfUserRepository _userRepository;

		public UnitOfWork(MyBlogContext context)
		{
			_context = context;
		}

		public IEducationRepository Educations => _educationRepository ?? new EfEducationRepository(_context);

		public IExperienceRepository Experiences => _experienceRepository ?? new EfExperienceRepository(_context);

		public IReferenceRepository References => _referenceRepository ?? new EfReferenceRepository(_context);

		public ISkillRepository Skills => _skillRepository ?? new EfSkillRepository(_context);

		public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
