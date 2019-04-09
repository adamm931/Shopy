using Shopy.Core.Application.Categories.Add;
using Shopy.Core.Application.Products.Add;
using System;
using System.Linq;

namespace Shopy.Api
{
    public class RequestParamValidator
    {
        public Func<bool> Rule { get; }

        public string Message { get; }

        public RequestParamValidator(Func<bool> rule, string message)
        {
            Rule = rule;
            Message = message;
        }

        public static RequestParamValidator ProductUidValidator(Guid? uid)
        {
            return new RequestParamValidator(
                () => uid == null, "Product uid is not valid Guid or its empty");
        }

        public static RequestParamValidator CategoryUidValidator(Guid? uid)
        {
            return new RequestParamValidator(
                () => uid == null, "Category uid is not valid Guid or its empty");
        }

        public static RequestParamValidator[] CategoryAddValidator(AddCategoryRequest addRequest)
        {
            return new[] {
                new RequestParamValidator(() => addRequest == null, "Request has to be set"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest.Caption), "Caption has to be set for category")
            };
        }

        public static RequestParamValidator[] ProductAddValidator(AddProductRequest addRequest)
        {
            return new[] {
                new RequestParamValidator(() => addRequest == null, "Request has to be set"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest.Brand), "Brand has to been set for product"),
                new RequestParamValidator(() => addRequest.Sizes == null || !addRequest.Sizes.Any(), "Sizes have to be set for product"),
                new RequestParamValidator(() => addRequest.Price == null, "Price has to be set for product"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest.Caption), "Caption has to be set for product"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest.Description), "Description has to be set for product")
            };

        }
    }
}