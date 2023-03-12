using System;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
    /// <summary>
    /// Thread-safe implementation of the Singleton pattern with lazy initialization of a generic type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object that the singleton should create.</typeparam>
    /// <remarks>
    /// This class guarantees that only one instance of type <see cref="T"/>
    /// is created during the lifetime of the application.
    /// </remarks>
    [Singleton]
    public class LazySingleton<T> where T : class, new()
    {
        private static readonly Lazy<T> LAZY = new Lazy<T>(() => new T());

        /// <summary>
        /// Gets the singleton instance of the specified generic type <see cref="T"/>.
        /// </summary>
        public static T Instance => LAZY.Value;

        /// <summary>
        /// Protected constructor to prevent instantiation of this class from outside.
        /// </summary>
        protected LazySingleton() { }
    }
}