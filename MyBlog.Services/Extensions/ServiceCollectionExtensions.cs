using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Abstract;
using MyBlog.Data.Concrete;
using MyBlog.Data.Concrete.EntityFramework.Context;
using MyBlog.Services.Abstract;
using MyBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<MyBlogContext>();
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
			serviceCollection.AddScoped<IEducationServices, EducationManager>();
			serviceCollection.AddScoped<IExperienceService, ExperienceManager>();
			serviceCollection.AddScoped<IReferenceServices, ReferenceManager>();
			serviceCollection.AddScoped<ISkillServices, SkillManager>();
			return serviceCollection;
		}
	}
}
