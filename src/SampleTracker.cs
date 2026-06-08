public class SampleTracker
{
    public bool ValidateSampleIntegrity(Sample sample)
    {
        if (sample == null)
            return false;

        if (!sample.PreviousStageCompleted)
            return false;

        if (sample.IsLost)
            return false;

        if (sample.IsDamaged)
            return false;

        if (sample.DelayHours > 24)
            return false;

        return true;
    }
}
public class Sample
{
    public bool PreviousStageCompleted { get; set; }
    public bool IsLost { get; set; }
    public bool IsDamaged { get; set; }
    public int DelayHours { get; set; }
}
// Refactored Function
public bool ValidateSampleIntegrity(Sample sample)
{
}
return sample != null
&& sample.PreviousStageCompleted
&& !sample.IsLost
&& !sample.IsDamaged
&& sample.DelayHours <= 24