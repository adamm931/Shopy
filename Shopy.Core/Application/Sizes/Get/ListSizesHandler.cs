using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Sizes.Get
{
    public class ListSizesHandler : IRequestHandler<ListSizesRequest, ListSizesResponse>
    {
        public async Task<ListSizesResponse> Handle(ReceiveContext<ListSizesRequest> context, CancellationToken cancellationToken)
        {
            var dbContext = ShopyContext.Current;
            var request = context.Message;

            var mapper = new SizeMapper();
            var sizes = await dbContext.SizeTypes.ToListAsync();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<SizeTypeEF, Size>();
            //    cfg.CreateMap<ProductEF, Product>();
            //    cfg.CreateMap<CategoryEF, Size>();
            //    cfg.CreateMap<Brand, Size>();
            //    cfg.CreateMap<SizeTypeEF, Size>();

            //});

            ////var mapper = config.CreateMapper();
            var projection = sizes.Select(s => mapper.FromEF(s));

            return new ListSizesResponse(projection);

        }
    }
}