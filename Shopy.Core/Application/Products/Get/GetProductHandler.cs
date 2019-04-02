﻿using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Shopy.Core.Mappers;
using Shopy.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        public async Task<GetProductResponse> Handle(ReceiveContext<GetProductRequest> context, CancellationToken cancellationToken)
        {
            using (var dbContext = new ShopyContext())
            {
                var request = context.Message;
                var product = await dbContext.Products
                    .Include(p => p.Sizes)
                    .SingleAsync(p => p.Uid == request.Uid);

                var productMapper = new ProductMapper();
                return new GetProductResponse(productMapper.FromEF(product));
            }
        }
    }
}