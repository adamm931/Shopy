using Mediator.Net.Contracts;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ListResponse<T> : IResponse
    {
        public IEnumerable<T> Result { get; set; }

        public int TotalRecords { get; set; }
        public ListResponse(IEnumerable<T> result, int totalRecords)
        {
            Result = result;
            TotalRecords = totalRecords;
        }
    }
}
