using System;
using System.Threading.Tasks;
using Quartz;

namespace TopShelfQuartz.Quartz.Interfaces
{
    public interface IQuartzScheduleJobManager
    {
        Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger)
            where TJob : IJob;

        Task Start();
        Task Stop();
    }
}