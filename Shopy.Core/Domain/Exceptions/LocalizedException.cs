using System;

namespace Shopy.Core.Domain.Exceptions
{
    public class LocalizedException : Exception
    {
        public LocalizedException(string resource, params object[] @params)
            : base(GetFormattedResource(resource, @params))
        {
        }

        private static string GetFormattedResource(string name, params object[] @params)
        {
            var content = ExceptionsLocalization.ResourceManager.GetString(name) ?? name;

            return string.Format(content, @params);
        }
    }
}
