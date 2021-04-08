using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Ordering.Application.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public Dictionary<string, string[]> Error { get;}

        public CustomValidationException() : base("Validation failure occurred.")
        {
            Error = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Error = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}