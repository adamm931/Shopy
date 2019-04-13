using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Categories.Add
{
    public class GetCategoryRequest : IRequest
    {
        public Guid Uid { get; set; }

        public GetCategoryRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}