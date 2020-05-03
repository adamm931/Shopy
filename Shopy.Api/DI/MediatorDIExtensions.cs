using MediatR;
using Shopy.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Lifetime;

namespace Shopy.Api.DI
{
    public static class MediatorDIExtensions
    {
        public static IUnityContainer RegisterMediator(this IUnityContainer container, ITypeLifetimeManager lifetimeManager)
        {
            return container
                .RegisterType<IMediator, Mediator>(lifetimeManager)
                .RegisterInstance<ServiceFactory>(type =>
                {
                    var enumerableType = type
                        .GetInterfaces()
                        .Concat(new[] { type })
                        .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    return enumerableType != null
                        ? container.ResolveAll(enumerableType.GetGenericArguments()[0])
                        : container.IsRegistered(type)
                            ? container.Resolve(type)
                            : null;
                });
        }

        public static IUnityContainer RegisterMediatorHandlers(this IUnityContainer container, Assembly assembly)
        {
            container.RegisterType(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>), "LoggingPipeline");
            container.RegisterTypesImplementingType(assembly, typeof(IRequestHandler<,>));

            return container;
        }

        public static IUnityContainer RegisterTypesImplementingType(this IUnityContainer container, Assembly assembly, Type type)
        {
            foreach (var implementation in assembly.GetTypes().Where(t => t.GetInterfaces().Any(implementation => IsSubclassOfRawGeneric(type, implementation))))
            {
                var interfaces = implementation.GetInterfaces();
                foreach (var @interface in interfaces)
                    container.RegisterType(@interface, implementation);
            }

            return container;
        }

        public static IUnityContainer RegisterNamedTypesImplementingType(this IUnityContainer container, Assembly assembly, Type type)
        {
            foreach (var implementation in assembly.GetTypes().Where(t => t.GetInterfaces().Any(implementation => IsSubclassOfRawGeneric(type, implementation))))
            {
                var interfaces = implementation.GetInterfaces();
                foreach (var @interface in interfaces)
                    container.RegisterType(@interface, implementation, implementation.FullName);
            }

            return container;
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var currentType = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == currentType)
                    return true;

                toCheck = toCheck.BaseType;
            }

            return false;
        }
    }
}