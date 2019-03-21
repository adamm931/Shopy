using Mediator.Net.Contracts;
using System;

namespace Shopy.Api.Application.Categories.Commands
{
    public class AddCategoryResponse : IResponse
    {
        public Guid Uid { get; set; }

        public long CategoryID { get; set; }

        public string Caption { get; set; }
    }
}