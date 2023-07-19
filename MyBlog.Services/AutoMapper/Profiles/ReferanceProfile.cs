using AutoMapper;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.ReferanceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Profiles
{
	public class ReferanceProfile : Profile
	{
		public ReferanceProfile() 
		{
			CreateMap<ReferenceAddDto, Reference>();
			CreateMap<ReferenceUpdateDto, Reference>();
			CreateMap<Reference, ReferenceUpdateDto>();
		}
	}
}
