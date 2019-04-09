using System.Collections.Generic;
using System.Linq;

namespace Shopy.Proto.Models
{
    public class ListResponse<T>
    {
        public IEnumerable<T> Result { get; set; }
        public ListResponse()
        {
            Result = Enumerable.Empty<T>();
        }
    }
}
