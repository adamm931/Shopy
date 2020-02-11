using System;

namespace Shopy.Application.Models
{
    public class RequestParamValidator
    {
        public Func<bool> Rule { get; }

        public string Message { get; }

        public RequestParamValidator(Func<bool> rule, string message)
        {
            Rule = rule;
            Message = message;
        }
    }
}