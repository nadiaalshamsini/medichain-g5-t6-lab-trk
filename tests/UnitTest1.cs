using System.Net.NetworkInformation;
using Xunit;
namespace Unit_Testing;
public class SampleTrackingModule
{
    public string MoveToNextStage(bool isPreviousStageDocumented)
    {
      if (isPreviousStageDocumented)
        {
            return "Success: Moved to the next stage. ";
        }   
        else
        {
            return "Alert: Cannot move! Previous stage is not documented.";
        }
    }
    public string CheckDelay(int hoursElapsed , int maxAllowedHours)
    {
        if(hoursElapsed > maxAllowedHours)
        {
            return "Alert: Delay detected in this stage! ";
        }
        else
        {
            return "Normal: Within time limits. ";
        }
    }
}

public class TrackingTests
{
    [Fact]
    public void Test_Tracking_Logic_When_Not_Documented()
    {
        var module = new SampleTrackingModule();
        string result = module.MoveToNextStage(false);
        Assert.Contains("Alert",result);
    }
    [Fact] 
    public void Test_Delay_Logic()
    {
        var module = new SampleTrackingModule();
        string result = module.CheckDelay(5,3);
        Assert.Contains("Alert", result);
    }
}