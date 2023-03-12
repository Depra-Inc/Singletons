using Depra.Singletons.Entities;

namespace Singletons.UnitTests;

[TestFixture(TestOf = typeof(LazySingleton<>))]
internal sealed class LazySingletonTests
{
    [Test]
    public void Instance_ReturnsSameInstance_ForSingleThread()
    {
        // Arrange.
        var instance1 = LazySingleton<Singleton>.Instance;
        var instance2 = LazySingleton<Singleton>.Instance;

        // Act.

        // Assert.
        instance2.Should().Be(instance1);
    }
    
    [Test]
    public void Instance_ReturnsSameInstance_ForMultipleThreads()
    {
        // Arrange.
        Singleton instance1 = null!, instance2 = null!;
        var task1 = Task.Run(() => instance1 = LazySingleton<Singleton>.Instance);
        var task2 = Task.Run(() => instance2 = LazySingleton<Singleton>.Instance);
        Task.WaitAll(task1, task2);

        // Act.

        // Assert.
        instance1.Should().NotBeNull();
        instance2.Should().NotBeNull();
        instance2.Should().Be(instance1);
    }

    [Test]
    public void Instance_ReturnsNonNullValue()
    {
        // Arrange.

        // Act.
        var instance = LazySingleton<Singleton>.Instance;

        // Assert.
        instance.Should().NotBeNull();
    }

    private sealed class Singleton { }
}