using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.EducationDtos;
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
	public class EducationManager : IEducationServices
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public EducationManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}


		#region Add Education
		public async Task<IDataResult<EducationDto>> AddAsync(EducationAddDto educationAddDto)
		{
			var education = _mapper.Map<Education>(educationAddDto);
			var addedEducation = await _unitOfWork.Educations.AddAsync(education);
			await _unitOfWork.SaveAsync();
			return new DataResult<EducationDto>(ResultStatus.Success, Messages.Education.Add(addedEducation.Level), new EducationDto
			{
				Education = addedEducation,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Education.Add(addedEducation.Level)
			});
		}
		#endregion

		#region Delete Education
		public async Task<IResult> DeleteAsync(int educationId)
		{
			var result = await _unitOfWork.Educations.AnyAsync(e => e.Id == educationId);
			if (result)
			{
				var education = await _unitOfWork.Educations.GetAsync(e => e.Id == educationId);
				await _unitOfWork.Educations.DeleteAsync(education);
				await _unitOfWork.SaveAsync();
				return new Result(ResultStatus.Success, Messages.Education.Delete(education.Level));
			}
			return new Result(ResultStatus.Error, Messages.Education.NotFound(isPlural: false));
		}
		#endregion

		#region GetById Education
		public async Task<IDataResult<EducationDto>> GetByIdAsync(int educationId)
		{
			var education = await _unitOfWork.Educations.GetAsync(e => e.Id == educationId);
			if (education != null)
			{
				return new DataResult<EducationDto>(ResultStatus.Success, new EducationDto
				{
					Education = education,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<EducationDto>(ResultStatus.Error, Messages.Education.NotFound(isPlural: false), new EducationDto
			{
				Education = education,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Education.NotFound(isPlural: false)
			});
		}
		#endregion

		#region GetAll Education
		public async Task<IDataResult<EducationListDto>> GetAllAsync()
		{
			var educations = await _unitOfWork.Educations.GetAllAsync(null);
			if (educations.Count > -1)
			{
				return new DataResult<EducationListDto>(ResultStatus.Success, new EducationListDto
				{
					Educations = educations,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<EducationListDto>(ResultStatus.Error, Messages.Education.NotFound(isPlural: true), new EducationListDto
			{
				Educations = educations,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Education.NotFound(isPlural: true)
			});
		}
		#endregion

		#region Update Education
		public async Task<IDataResult<EducationDto>> UpdateAsync(EducationUpdateDto educationUpdateDto)
		{
			var oldEducation = await _unitOfWork.Educations.GetAsync(e => e.Id == educationUpdateDto.Id);
			var education = _mapper.Map<EducationUpdateDto, Education>(educationUpdateDto, oldEducation);
			var updatedEducation = await _unitOfWork.Educations.UpdateAsync(education);
			await _unitOfWork.SaveAsync();
			return new DataResult<EducationDto>(ResultStatus.Success, Messages.Education.Update(updatedEducation.Level), new EducationDto
			{
				Education = education,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Education.Update(updatedEducation.Level)
			});
		}
		#endregion
	}
}
