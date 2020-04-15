using System.Collections.Generic;

namespace Shopy.Application.Models
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

        public ListResponse(IEnumerable<TDomainModel> domainModel)
            : base(domainModel)
        {
            TotalRecords = -1;
        }
    }
}
