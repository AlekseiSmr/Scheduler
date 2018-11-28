using Quartz;
using Quartz.Impl;
using TopShelfQuartz.Quartz.Interfaces;

namespace TopShelfQuartz.Quartz
{
    public class QuartzConfiguration : IQuartzConfiguration
    {
        public IScheduler Scheduler => StdSchedulerFactory.GetDefaultScheduler().Result;
    }
}