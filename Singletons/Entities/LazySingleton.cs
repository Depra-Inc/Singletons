using System;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
	/// <summary>
	/// Thread-safe implementation of the Singleton pattern with lazy initialization of a generic type <see cref="TSelf"/>.
	/// </summary>
	/// <typeparam name="TSelf">The type of object that the singleton should create.</typeparam>
	/// <remarks>
	/// This class guarantees that only one instance of type <see cref="TSelf"/>
	/// is created during the lifetime of the application.
	/// </remarks>
	[Singleton]
	public class LazySingleton<TSelf> where TSelf : class, new()
	{
		private static readonly Lazy<TSelf> LAZY = new(() => new TSelf());

		/// <summary>
		/// Gets the singleton instance of the specified generic type <see cref="TSelf"/>.
		/// </summary>
		public static TSelf Instance => LAZY.Value;

		/// <summary>
		/// Protected constructor to prevent instantiation of this class from outside.
		/// </summary>
		protected LazySingleton() { }
	}
}