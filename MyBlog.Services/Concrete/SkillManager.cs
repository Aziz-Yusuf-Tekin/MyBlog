using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.SkillDtos;
using MyBlog.Services.Abstract;
using MyBlog.Services.Utilities;
using MyBlog.Shared.Utilities.Result.Abstract;
using MyBlog.Shared.Utilities.Result.ComplexTypes;
using MyBlog.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Concrete
{
	public class SkillManager : ISkillServices
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SkillManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region AddAsync Skill
		public async Task<IDataResult<SkillDto>> AddAsync(SkillAddDto skillAddDto)
		{
			var skill = _mapper.Map<Skill>(skillAddDto);
			var addedSkill = await _unitOfWork.Skills.AddAsync(skill);
			await _unitOfWork.SaveAsync();
			return new DataResult<SkillDto>(ResultStatus.Success, Messages.Skill.Add(addedSkill.Name), new SkillDto
			{
				Skill = skill,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Skill.Add(addedSkill.Name)
			});
		}
		#endregion

		#region DeleteAsync Skill
		public async Task<IResult> DeleteAsync(int skillId)
		{
			var result = await _unitOfWork.Skills.AnyAsync(s => s.Id == skillId);
			if (result)
			{
				var skill = await _unitOfWork.Skills.GetAsync(s => s.Id == skillId);
				await _unitOfWork.Skills.DeleteAsync(skill);
				await _unitOfWork.SaveAsync();
				return new Result(ResultStatus.Success, Messages.Skill.Delete(skill.Name));
			}
			return new Result(ResultStatus.Error, Messages.Skill.NotFound(isPlural: false));
		}

		#endregion

		#region GetAllAsync Skill
		public async Task<IDataResult<SkillListDto>> GetAllAsync()
		{
			var skills = await _unitOfWork.Skills.GetAllAsync(null);
			if (skills.Count > -1)
			{
				return new DataResult<SkillListDto>(ResultStatus.Success, new SkillListDto
				{
					Skills = skills,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<SkillListDto>(ResultStatus.Error, Messages.Skill.NotFound(isPlural: true), new SkillListDto
			{
				Skills = skills,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Skill.NotFound(isPlural:true)
			});
		}
		#endregion

		#region GetByIdAsync Skill
		public async Task<IDataResult<SkillDto>> GetByIdAsync(int skillId)
		{
			var skill = await _unitOfWork.Skills.GetAsync(s => s.Id == skillId);
			if (skill != null)
			{
				return new DataResult<SkillDto>(ResultStatus.Success, new SkillDto
				{
					Skill = skill,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<SkillDto>(ResultStatus.Error, Messages.Skill.NotFound(isPlural:false), new SkillDto
			{
				Skill = skill,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Skill.NotFound(isPlural: false)
			});
		}
		#endregion

		#region UpdateAsync Skill
		public async Task<IDataResult<SkillDto>> UpdateAsync(SkillUpdateDto skillUpdateDto)
		{
			var oldSkill = await _unitOfWork.Skills.GetAsync(s => s.Id == skillUpdateDto.Id);
			var skill = _mapper.Map<SkillUpdateDto, Skill>(skillUpdateDto, oldSkill);
			var updateSkill = await _unitOfWork.Skills.UpdateAsync(skill);
			await _unitOfWork.SaveAsync();
			return new DataResult<SkillDto>(ResultStatus.Success, Messages.Skill.Update(updateSkill.Name), new SkillDto
			{
				Skill= skill,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Skill.Update(updateSkill.Name)
			});
		}

		#endregion
	}
}
