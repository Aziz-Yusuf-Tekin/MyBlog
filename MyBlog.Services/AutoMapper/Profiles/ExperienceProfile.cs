using AutoMapper;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.ExperienceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Profiles
{
	public class ExperienceProfile : Profile
	{
		public ExperienceProfile()
		{
			CreateMap<ExperienceAddDto, Experience>();
			CreateMap<ExperienceUpdateDto, Experience>();
			CreateMap<Experience, ExperienceUpdateDto>();
		}
	}
}
