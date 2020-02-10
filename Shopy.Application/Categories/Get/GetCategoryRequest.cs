using MediatR;
using System;

namespace Shopy.Application.Categories.Add
{
    public class GetCategoryRequest : IRequest<GetCategoryResponse>
    {
        public Guid Uid { get; set; }

        public GetCategoryRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}