﻿using MyBlog.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Entities.Abstract
{
	public abstract class DtoGetBase
	{
		public virtual ResultStatus ResultStatus { get; set; }
		public virtual string Message { get; set; }
	}
}
