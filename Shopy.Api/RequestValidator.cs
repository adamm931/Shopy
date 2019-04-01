using System;

namespace Shopy.Api
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