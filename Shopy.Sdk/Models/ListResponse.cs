using System.Collections.Generic;
using System.Linq;

namespace Shopy.Sdk.Models
{
    public class ListResponse<T>
    {
        public List<T> Result { get; set; } = new List<T>();

        public int TotalRecords => Result.Count();
    }
}
