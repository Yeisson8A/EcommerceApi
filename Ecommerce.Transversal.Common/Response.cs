﻿using FluentValidation.Results;
using System.Collections.Generic;

namespace Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
