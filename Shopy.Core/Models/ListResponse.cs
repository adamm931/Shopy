using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ListResponse<TReponseModel, TDomainModel>
        : Response<IEnumerable<TReponseModel>, IEnumerable<TDomainModel>>
    {
        public int TotalRecords { get; set; }

        public ListResponse(IEnumerable<TDomainModel> domainModel, int totalCount)
            : base(domainModel)
        {
            TotalRecords = totalCount;
        }
    }
}
