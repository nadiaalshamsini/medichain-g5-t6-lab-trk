using System;

namespace Mytestproject
{
    public enum StageStatus { Pending, Completed, Delayed, Error }

    public class SampleTracker
    {
        public StageStatus GetStageCompletionStatus(bool isPreviousCompleted, int timeSpentInHours, int maxAllowedHours, bool isLogged)
        {
            if (!isPreviousCompleted) return StageStatus.Error;

            if (!isLogged) return StageStatus.Pending;

            if (timeSpentInHours > maxAllowedHours) 
            {
                if (timeSpentInHours > maxAllowedHours * 2) return StageStatus.Error; 
                return StageStatus.Delayed;
            }

            return StageStatus.Completed;
        }
    }
}