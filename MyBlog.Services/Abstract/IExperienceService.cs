using MyBlog.Entities.Dtos.ExperienceDtos;
using MyBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
	public interface IExperienceService
	{
		Task<IDataResult<ExperienceDto>> GetByIdAsync(int experienceId);
		Task<IDataResult<ExperienceListDto>> GetAllAsync();
		Task<IDataResult<ExperienceDto>> AddAsync(ExperienceAddDto experienceDto);
		Task<IDataResult<ExperienceDto>> UpdateAsync(ExperienceUpdateDto experienceUpdateDto);
		Task<IResult> DeleteAsync(int experienceId);
	}
}
