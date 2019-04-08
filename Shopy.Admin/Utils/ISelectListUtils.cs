using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Utils
{
    public interface ISelectListUtils
    {
        Task<IEnumerable<SelectListItem>> GetBrandsSL();

        Task<MultiSelectList> GetSizesMSL();
    }
}
