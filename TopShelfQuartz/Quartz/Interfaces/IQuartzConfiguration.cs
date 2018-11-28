using Quartz;

namespace TopShelfQuartz.Quartz.Interfaces
{
    public interface IQuartzConfiguration
    {
        IScheduler Scheduler { get; }
    }
}