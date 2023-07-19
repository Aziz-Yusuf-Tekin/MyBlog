using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.ExperienceDtos;
using MyBlog.Services.Abstract;
using MyBlog.Services.Utilities;
using MyBlog.Shared.Utilities.Result.Abstract;
using MyBlog.Shared.Utilities.Result.ComplexTypes;
using MyBlog.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Concrete
{
	public class ExperienceManager : IExperienceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ExperienceManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region Add Experience
		public async Task<IDataResult<ExperienceDto>> AddAsync(ExperienceAddDto experienceAddDto)
		{
			var experience = _mapper.Map<Experience>(experienceAddDto);
			var addedExperience = await _unitOfWork.Experiences.AddAsync(experience);
			await _unitOfWork.SaveAsync();
			return new DataResult<ExperienceDto>(ResultStatus.Success, Messages.Experience.Add(addedExperience.Place), new ExperienceDto
			{
				Experience = addedExperience,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Education.Add(addedExperience.Place)
			});
		}
		#endregion

		#region Delete Experience
		public async Task<IResult> DeleteAsync(int experienceId)
		{
			var result = await _unitOfWork.Experiences.AnyAsync(e => e.Id == experienceId);
			if (result)
			{
				var experience = await _unitOfWork.Experiences.GetAsync(e => e.Id == experienceId);
				await _unitOfWork.Experiences.DeleteAsync(experience);
				await _unitOfWork.SaveAsync();
				return new Result(ResultStatus.Success, Messages.Experience.Delete(experience.Place));
			}
			return new Result(ResultStatus.Error, Messages.Experience.NotFound(isPlural: false));
		}
		#endregion

		#region GettAll experience
		public async Task<IDataResult<ExperienceListDto>> GetAllAsync()
		{
			var experiences = await _unitOfWork.Experiences.GetAllAsync(null);
			if (experiences.Count > -1)
			{
				return new DataResult<ExperienceListDto>(ResultStatus.Success, new ExperienceListDto
				{
					Experiences = experiences,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<ExperienceListDto>(ResultStatus.Error, Messages.Experience.NotFound(isPlural: true), new ExperienceListDto
			{
				Experiences = experiences,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Experience.NotFound(isPlural: true)
			});
		}
		#endregion

		#region GetById Experience
		public async Task<IDataResult<ExperienceDto>> GetByIdAsync(int experienceId)
		{
			var experience = await _unitOfWork.Experiences.GetAsync(e => e.Id == experienceId);
			if (experience != null)
			{
				return new DataResult<ExperienceDto>(ResultStatus.Success, new ExperienceDto
				{
					Experience = experience,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<ExperienceDto>(ResultStatus.Error, Messages.Experience.NotFound(isPlural:false), new ExperienceDto
			{
				Experience = experience,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Experience.NotFound(isPlural: false)
			});
		}
		#endregion

		#region Update Experience
		public async Task<IDataResult<ExperienceDto>> UpdateAsync(ExperienceUpdateDto experienceUpdateDto)
		{
			var oldExperience = await _unitOfWork.Experiences.GetAsync(e => e.Id == experienceUpdateDto.Id);
			var experience = _mapper.Map<ExperienceUpdateDto, Experience>(experienceUpdateDto, oldExperience);
			var updateExperience = await _unitOfWork.Experiences.UpdateAsync(experience);
			await _unitOfWork.SaveAsync();
			return new DataResult<ExperienceDto>(ResultStatus.Success, Messages.Experience.Update(updateExperience.Place), new ExperienceDto 
			{
				Experience = experience,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Experience.Update(updateExperience.Place)
			});
		}
		#endregion

	}
}
