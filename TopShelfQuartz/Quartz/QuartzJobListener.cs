using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace TopShelfQuartz.Quartz
{
    public class QuartzJobListener : IJobListener
    {
        public Task JobToBeExecuted(
            IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            Console.WriteLine($"Job {context.JobDetail.JobType.Name} executing...");
            return Task.CompletedTask;
        }

        public Task JobExecutionVetoed(
            IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            Console.WriteLine($"Job {context.JobDetail.JobType.Name} executing operation vetoed...");
            return Task.CompletedTask;
        }

        public Task JobWasExecuted(
            IJobExecutionContext context, JobExecutionException jobException,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            Console.WriteLine($"Job {context.JobDetail.JobType.Name} sucessfully executed.");
            return Task.CompletedTask;
        }

        public string Name { get; } = "JobListener";
    }
}