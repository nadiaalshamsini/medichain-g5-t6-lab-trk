using Xunit;

public class SampleTrackerTests
{
    [Fact]
    public void ValidateSampleIntegrity_ValidSample_ReturnsTrue()
    {
        var sample = new Sample
        {
            PreviousStageCompleted = true,
            IsLost = false,
            IsDamaged = false,
            DelayHours = 5
        };

        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.True(result);
    }

    [Fact]
    public void ValidateSampleIntegrity_NullSample_ReturnsFalse()
    {
        Sample sample = null;
        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.False(result);
    }

    [Fact]
    public void ValidateSampleIntegrity_PreviousStageNotCompleted_ReturnsFalse()
    {
        var sample = new Sample
        {
            PreviousStageCompleted = false,
            IsLost = false,
            IsDamaged = false,
            DelayHours = 5
        };

        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.False(result);
    }

    [Fact]
    public void ValidateSampleIntegrity_LostSample_ReturnsFalse()
    {
        var sample = new Sample
        {
            PreviousStageCompleted = true,
            IsLost = true,
            IsDamaged = false,
            DelayHours = 5
        };

        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.False(result);
    }

    [Fact]
    public void ValidateSampleIntegrity_DamagedSample_ReturnsFalse()
    {
        var sample = new Sample
        {
            PreviousStageCompleted = true,
            IsLost = false,
            IsDamaged = true,
            DelayHours = 5
        };

        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.False(result);
    }

    [Fact]
    public void ValidateSampleIntegrity_DelayedSample_ReturnsFalse()
    {
        var sample = new Sample
        {
            PreviousStageCompleted = true,
            IsLost = false,
            IsDamaged = false,
            DelayHours = 30
        };

        var tracker = new SampleTracker();

        bool result = tracker.ValidateSampleIntegrity(sample);

        Assert.False(result);
    }
}