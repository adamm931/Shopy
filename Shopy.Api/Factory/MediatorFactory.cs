using Mediator.Net;
using System;

namespace Shopy.Api.Factory
{
    public class MediatorFactory
    {
        private static Lazy<IMediator> _current =
            new Lazy<IMediator>(() => CreateMediator(), isThreadSafe: true);

        public static IMediator GetMediator()
        {
            return _current.Value;
        }

        private static IMediator CreateMediator()
        {
            return new MediatorBuilder()
                .RegisterHandlers(typeof(MediatorFactory).Assembly)
                .Build();
        }
    }
}