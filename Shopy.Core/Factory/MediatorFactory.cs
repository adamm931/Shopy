using MediatR;
using System;

namespace Shopy.Core.Factory
{
    public class MediatorFactory
    {
        private static readonly Lazy<IMediator> _current =
            new Lazy<IMediator>(() => CreateMediator(), isThreadSafe: true);

        public static IMediator GetMediator()
        {
            return _current.Value;
        }

        private static IMediator CreateMediator()
        {
            return new Mediator((type) => new { });
        }
    }
}