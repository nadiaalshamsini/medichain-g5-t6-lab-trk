using Xunit;
using Mytestproject; // تم تعديل الحرف الأول إلى M كبيرة ليطابق التابع تماماً

namespace MediChain.Tests
{
    public class SampleTrackerTests
    {
        [Fact]
        public void GetStageStatus_PreviousNotCompleted_ReturnsError()
        {
            var tracker = new SampleTracker();
            var result = tracker.GetStageCompletionStatus(false, 2, 5, true);
            Assert.Equal(StageStatus.Error, result);
        }

        [Fact]
        public void GetStageStatus_NotLogged_ReturnsPending()
        {
            var tracker = new SampleTracker();
            var result = tracker.GetStageCompletionStatus(true, 2, 5, false);
            Assert.Equal(StageStatus.Pending, result);
        }

        [Fact]
        public void GetStageStatus_TimeExceeded_ReturnsDelayed()
        {
            var tracker = new SampleTracker();
            var result = tracker.GetStageCompletionStatus(true, 7, 5, true); 
            Assert.Equal(StageStatus.Delayed, result);
        }

        [Fact]
        public void GetStageStatus_WithinTime_ReturnsCompleted()
        {
            var tracker = new SampleTracker();
            var result = tracker.GetStageCompletionStatus(true, 3, 5, true); 
            Assert.Equal(StageStatus.Completed, result);
        }
    }
}