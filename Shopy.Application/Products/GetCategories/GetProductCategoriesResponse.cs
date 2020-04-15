using Shopy.Application.Models;
using Shopy.Core.Domain.Entitties;
using System.Collections.Generic;

namespace Shopy.Application.Products.Get
{
    public class GetProductCategoriesResponse : Response<List<ProductCategoryResponse>, List<Category>>
    {
        public GetProductCategoriesResponse(List<Category> domainModel) : base(domainModel)
        { }
    }
}