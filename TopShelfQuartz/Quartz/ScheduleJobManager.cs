using System;
using System.Threading.Tasks;
using Quartz;
using TopShelfQuartz.Quartz.Interfaces;
using TopShelfQuartz.Quartz.Jobs;

namespace TopShelfQuartz.Quartz
{
    public class ScheduleJobManager : IQuartzScheduleJobManager
    {
        private readonly IQuartzConfiguration _configuration;

        public ScheduleJobManager(
            IQuartzConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        public async Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger)
            where TJob : IJob
        {
            var jobToBuild = JobBuilder.Create<TJob>();
            configureJob(jobToBuild);
            var job = jobToBuild.Build();

            var triggerToBuild = TriggerBuilder.Create();
            configureTrigger(triggerToBuild);
            var trigger = triggerToBuild.Build();

            await _configuration.Scheduler.ScheduleJob(job, trigger);
        }

        public async Task Start()
        {
            await ConfigureJobs();
            await _configuration.Scheduler.Start();
        }

        public async Task Stop()
        {
            await _configuration.Scheduler.Shutdown();
        }

        private async Task ConfigureJobs()
        {
            await ScheduleAsync<SimpleJob>(
                job =>
                {
                    job.WithDescription("SimpleJobDescription")
                        .WithIdentity("SimpleJobJobKey");
                },
                trigger =>
                {
                    trigger.WithIdentity("SimpleJobTrigger")
                        .WithDescription("SimpleJobTriggerDescription")
                        .WithSimpleSchedule(
                            schedule => schedule.WithRepeatCount(5).WithInterval(TimeSpan.FromSeconds(5))
                        )
                        .StartNow();
                });

            await ScheduleAsync<MediumJob>(
                job =>
                {
                    job.WithDescription("MediumJobDescription")
                        .WithIdentity("MediumJobJobKey");
                },
                trigger =>
                {
                    trigger.WithIdentity("MediumJobTrigger")
                        .WithDescription("MediumJobTriggerDescription")
                        .WithSimpleSchedule(
                            schedule => schedule.WithRepeatCount(5).WithInterval(TimeSpan.FromSeconds(4))
                        )
                        .StartNow();
                });
        }
    }
}