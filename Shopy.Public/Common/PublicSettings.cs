using System.Configuration;

namespace Shopy.Public.Common
{
    public class PublicSettings
    {
        private static int? pageSize;
        public static int PageSize
        {
            get
            {
                if (pageSize == null)
                {
                    var pageSizeSetting = ConfigurationManager.AppSettings[PublicSettingsKeys.PageSize];

                    if (pageSizeSetting == null)
                    {
                        pageSize = 9;
                    }

                    int retVal;

                    if (!int.TryParse(pageSizeSetting, out retVal))
                    {
                        throw new System.Exception("Page size setting is not valid integer.");
                    }

                    pageSize = retVal;
                }

                return pageSize.Value;
            }
        }
    }
}