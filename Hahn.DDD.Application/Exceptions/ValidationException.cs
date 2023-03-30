using FluentValidation.Results;

namespace Hahn.DDD.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("One or more error happened in the operation")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup =>  failureGroup.ToArray());
        }

        public Dictionary<string, string[]> Errors { get;}
    }
}
