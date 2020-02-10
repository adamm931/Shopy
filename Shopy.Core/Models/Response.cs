using Shopy.Core.Mappings;

namespace Shopy.Core.Models
{
    public class Response<TResponseModel, TDomainModel>
    {
        public TResponseModel Result { get; }

        public Response(TDomainModel result)
        {
            Result = result.MapTo<TResponseModel>();
        }
    }
}
