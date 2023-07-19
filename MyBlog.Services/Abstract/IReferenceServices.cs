using MyBlog.Entities.Dtos.ReferanceDtos;
using MyBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Abstract
{
	public interface IReferenceServices
	{
		Task<IDataResult<ReferenceDto>> GetByIdAsync(int referenceId);
		Task<IDataResult<ReferenceListDto>> GetAllAsync();
		Task<IDataResult<ReferenceDto>> AddAsync(ReferenceAddDto referenceAddDto);
		Task<IDataResult<ReferenceDto>> UpdateAsync(ReferenceUpdateDto referenceUpdateDto);
		Task<IResult> DeleteAsync(int referenceId);
	}
}
