using System.Runtime.CompilerServices;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
    /// <summary>
    /// Thread-safe implementation of the Singleton pattern with eager initialization of a generic type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object that the singleton should create.</typeparam>
    /// <remarks>
    /// This class guarantees that only one instance of type <see cref="T"/>
    /// is created during the lifetime of the application.
    /// </remarks>
    [Singleton]
    public class Singleton<T> where T : class, new()
    {
        private static readonly object OBJECT_LOCK = new object();
        private static T _instance;

        /// <summary>
        /// Gets the singleton instance of the specified generic type <see cref="T"/>.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateInstance();
                }

                return _instance;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CreateInstance()
        {
            lock (OBJECT_LOCK)
            {
                _instance = new T();
            }
        }

        /// <summary>
        /// Protected constructor to prevent instantiation of this class from outside.
        /// </summary>
        protected Singleton() { }
    }
}