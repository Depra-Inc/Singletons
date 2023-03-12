using System.Runtime.CompilerServices;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
    [Singleton]
    public class Singleton<T> where T : class, new()
    {
        private static readonly object OBJECT_LOCK = new object();
        private static T _instance;

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
    }
}