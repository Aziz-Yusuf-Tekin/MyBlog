using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.EducationDtos;
using MyBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
	public interface IEducationServices
	{
		Task<IDataResult<EducationDto>> GetByIdAsync(int educationId);
		Task<IDataResult<EducationListDto>> GetAllAsync();
		Task<IDataResult<EducationDto>> AddAsync(EducationAddDto educationDto);
		Task<IDataResult<EducationDto>> UpdateAsync(EducationUpdateDto educationUpdateDto);
		Task<IResult> DeleteAsync(int educationId);
	}
}
