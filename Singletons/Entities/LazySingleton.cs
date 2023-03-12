using System;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
    [Singleton]
    public class LazySingleton<T> where T : class, new()
    {
        private static readonly Lazy<T> LAZY = new Lazy<T>(() => new T());

        public static T Instance => LAZY.Value;

        protected LazySingleton() { }
    }
}