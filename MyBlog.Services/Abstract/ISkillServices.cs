using MyBlog.Entities.Dtos.SkillDtos;
using MyBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
	public interface ISkillServices
	{
		Task<IDataResult<SkillDto>> GetByIdAsync(int skillId);
		Task<IDataResult<SkillListDto>> GetAllAsync();
		Task<IDataResult<SkillDto>> AddAsync(SkillAddDto skillAddDto);
		Task<IDataResult<SkillDto>> UpdateAsync(SkillUpdateDto skillUpdateDto);
		Task<IResult> DeleteAsync(int skillId);
	}
}
