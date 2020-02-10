using Shopy.Application.Categories.Add;
using Shopy.Application.Categories.Edit;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.Edit;
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
                UidInvalidRule(uid), "Product uid is not valid Guid or its empty");
        }

        public static RequestParamValidator CategoryUidValidator(Guid? uid)
        {
            return new RequestParamValidator(
                UidInvalidRule(uid), "Category uid is not valid Guid or its empty");
        }

        public static RequestParamValidator[] CategoryAddValidator(AddCategoryRequest addRequest)
        {
            return new[] {
                new RequestParamValidator(() => addRequest == null, "Request has to be set"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest?.Caption), "Caption has to be set for category")
            };
        }

        public static RequestParamValidator[] CategoryEditValidator(EditCategoryCommand editCommand)
        {
            return new[] {
                new RequestParamValidator(() => editCommand == null, "Request has to be set"),
                CategoryUidValidator(editCommand?.Uid),
                new RequestParamValidator(() => string.IsNullOrEmpty(editCommand.Caption), "Caption has to be set for category")
            };
        }

        public static RequestParamValidator[] ProductAddValidator(AddProductRequest addRequest)
        {
            return new[] {
                new RequestParamValidator(() => addRequest == null, "Request has to be set"),
                //new RequestParamValidator(() => string.IsNullOrEmpty(addRequest?.Brand), "Brand has to been set for product"),
                new RequestParamValidator(() => addRequest?.Sizes == null || !addRequest.Sizes.Any(), "Sizes have to be set for product"),
                new RequestParamValidator(() => addRequest?.Price == null, "Price has to be set for product"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest?.Caption), "Caption has to be set for product"),
                new RequestParamValidator(() => string.IsNullOrEmpty(addRequest?.Description), "Description has to be set for product")
            };

        }

        public static RequestParamValidator[] ProductEditValidator(EditProductCommand editCommand)
        {
            return new[] {
                new RequestParamValidator(() => editCommand == null, "Request has to be set"),
                ProductUidValidator(editCommand?.Uid)
            };

        }

        private static Func<bool> UidInvalidRule(Guid? uid)
        {
            return () => uid == null || uid.Value == Guid.Empty;
        }
    }
}