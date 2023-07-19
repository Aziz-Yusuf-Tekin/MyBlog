using AutoMapper;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Profiles
{
	public class SkillProfile : Profile
	{
		public SkillProfile() 
		{
			CreateMap<SkillAddDto, Skill>();
			CreateMap<SkillUpdateDto, Skill>();
			CreateMap<Skill, SkillUpdateDto>();
		}
	}
}
