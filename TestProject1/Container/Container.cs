using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>();

        public void Bind(Type serviceType, Type implementationType)
        {
            _bindings[serviceType] = implementationType;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type serviceType)
        {
            if (!_bindings.TryGetValue(serviceType, out var implementationType))
            {
                throw new InvalidOperationException($"No binding exists for type '{serviceType.FullName}'.");
            }

            return Activator.CreateInstance(implementationType);
        }
    }
}