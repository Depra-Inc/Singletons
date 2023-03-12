using Depra.Singletons.Entities;

namespace Singletons.UnitTests;

[TestFixture(TestOf = typeof(Singleton<>))]
internal sealed class SingletonTests
{
    [Test]
    public void Instance_ReturnsSameInstance_ForSingleThread()
    {
        // Arrange.
        var instance1 = Singleton<Singleton>.Instance;
        var instance2 = Singleton<Singleton>.Instance;

        // Act.

        // Assert.
        instance2.Should().Be(instance1);
    }

    [Test]
    public void Instance_ReturnsSameInstance_ForMultipleThreads()
    {
        // Arrange.
        Singleton instance1 = null!, instance2 = null!;

        // Act.
        var task1 = Task.Run(() => instance1 = Singleton<Singleton>.Instance);
        var task2 = Task.Run(() => instance2 = Singleton<Singleton>.Instance);
        Task.WaitAll(task1, task2);

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
        var instance = Singleton<Singleton>.Instance;

        // Assert.
        instance.Should().NotBeNull();
    }

    private sealed class Singleton : Singleton<Singleton> { }
}