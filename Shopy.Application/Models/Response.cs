using Shopy.Application.Mappings;

namespace Shopy.Application.Models
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
