// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.CompilerServices;
using Depra.Singletons.Attributes;

namespace Depra.Singletons.Entities
{
	/// <summary>
	/// Thread-safe implementation of the Singleton pattern with eager initialization of a generic type <see cref="TSelf"/>.
	/// </summary>
	/// <typeparam name="TSelf">The type of object that the singleton should create.</typeparam>
	/// <remarks>
	/// This class guarantees that only one instance of type <see cref="TSelf"/>
	/// is created during the lifetime of the application.
	/// </remarks>
	[Singleton]
	public class Singleton<TSelf> where TSelf : class, new()
	{
		private static readonly object OBJECT_LOCK = new();
		private static TSelf _instance;

		/// <summary>
		/// Gets the singleton instance of the specified generic type <see cref="TSelf"/>.
		/// </summary>
		public static TSelf Instance => GetOrCreateInstance();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static TSelf GetOrCreateInstance()
		{
			if (_instance == null)
			{
				CreateInstance();
			}

			return _instance;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CreateInstance()
		{
			lock (OBJECT_LOCK)
			{
				_instance = new TSelf();
			}
		}

		/// <summary>
		/// Protected constructor to prevent instantiation of this class from outside.
		/// </summary>
		protected Singleton() { }
	}
}