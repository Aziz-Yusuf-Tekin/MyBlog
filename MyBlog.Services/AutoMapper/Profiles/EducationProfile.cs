using AutoMapper;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.EducationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Profiles
{
	public class EducationProfile : Profile
	{
		public EducationProfile() 
		{
			CreateMap<EducationAddDto, Education>();
			CreateMap<EducationUpdateDto, Education>();
			CreateMap<Education, EducationUpdateDto>();
		}
	}
}
