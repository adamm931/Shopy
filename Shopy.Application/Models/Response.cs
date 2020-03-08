using Shopy.Application.Mappings;

namespace Shopy.Application.Models
{
    public class Response<TResponseModel, TDomainModel> : Response<TResponseModel>
    {
        public Response(TDomainModel result) : base(result.MapTo<TResponseModel>())
        {
        }
    }

    public class Response<TResponseModel>
    {
        public TResponseModel Result { get; }

        public Response(TResponseModel result)
        {
            Result = result;
        }
    }
}
