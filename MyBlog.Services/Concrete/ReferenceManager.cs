using AutoMapper;
using MyBlog.Data.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.Dtos.ReferanceDtos;
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
	public class ReferenceManager : IReferenceServices
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ReferenceManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region Add Reference
		public async Task<IDataResult<ReferenceDto>> AddAsync(ReferenceAddDto referenceAddDto)
		{
			var reference = _mapper.Map<Reference>(referenceAddDto);
			var addedReference = await _unitOfWork.References.AddAsync(reference);
			await _unitOfWork.SaveAsync();
			return new DataResult<ReferenceDto>(ResultStatus.Success, Messages.Referance.Add(addedReference.Name), new ReferenceDto
			{
				Reference = addedReference,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Referance.Add(addedReference.Name)
			});
		}
		#endregion

		#region GetAll Reference
		public async Task<IDataResult<ReferenceListDto>> GetAllAsync()
		{
			var references = await _unitOfWork.References.GetAllAsync(null);
			if (references.Count > -1)
			{
				return new DataResult<ReferenceListDto>(ResultStatus.Success, new ReferenceListDto
				{
					References = references,
					ResultStatus = ResultStatus.Success
				});
			}
			return new DataResult<ReferenceListDto>(ResultStatus.Error, Messages.Referance.NotFound(isPlural: true), new ReferenceListDto 
			{
				References = references,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Referance.NotFound(isPlural: true)
			});
		}
		#endregion

		#region GetById Reference
		public async Task<IDataResult<ReferenceDto>> GetByIdAsync(int referenceId)
		{
			var reference = await _unitOfWork.References.GetAsync(r => r.Id == referenceId);
			if (reference != null)
			{
				return new DataResult<ReferenceDto>(ResultStatus.Success, new ReferenceDto
				{
					Reference = reference,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<ReferenceDto>(ResultStatus.Error, Messages.Referance.NotFound(isPlural: false), new ReferenceDto
			{
				Reference = reference,
				ResultStatus = ResultStatus.Error,
				Message = Messages.Referance.NotFound(isPlural: false)
			});
		}
		#endregion

		#region Delete Reference
		public async Task<IResult> DeleteAsync(int referenceId)
		{
			var result = await _unitOfWork.References.AnyAsync(r => r.Id == referenceId);
			if (result)
			{
				var reference = await _unitOfWork.References.GetAsync(r => r.Id == referenceId);
				await _unitOfWork.References.DeleteAsync(reference);
				await _unitOfWork.SaveAsync();
				return new Result(ResultStatus.Success, Messages.Referance.Delete(reference.Name));
			}
			return new Result(ResultStatus.Error, Messages.Referance.NotFound(isPlural: false));
		}
		#endregion

		#region Update Reference
		public async Task<IDataResult<ReferenceDto>> UpdateAsync(ReferenceUpdateDto referenceUpdateDto)
		{
			var oldReference = await _unitOfWork.References.GetAsync(r => r.Id == referenceUpdateDto.Id);
			var reference = _mapper.Map<ReferenceUpdateDto, Reference>(referenceUpdateDto, oldReference);
			var updateReference = await _unitOfWork.References.UpdateAsync(reference);
			return new DataResult<ReferenceDto>(ResultStatus.Success, Messages.Referance.Update(updateReference.Name), new ReferenceDto
			{
				Reference = reference,
				ResultStatus = ResultStatus.Success,
				Message = Messages.Referance.Update(updateReference.Name)
			});
		}
		#endregion
	}
}
