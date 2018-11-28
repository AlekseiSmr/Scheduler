using Quartz;
using Quartz.Spi;
using Stashbox;

namespace TopShelfQuartz.Quartz
{
    public class QuartzJobFactory : IJobFactory
    {
        private readonly IStashboxContainer _container;

        public QuartzJobFactory(
            IStashboxContainer container
        )
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _container.Resolve<IJob>(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}