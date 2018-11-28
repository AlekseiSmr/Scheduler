using Quartz;
using Stashbox;
using TopShelfQuartz.Quartz.Interfaces;

namespace TopShelfQuartz.Quartz
{
    public class QuartzModule : ICompositionRoot
    {
        public void Compose(IStashboxContainer container)
        {
            container.RegisterAssemblyContaining<IQuartzConfiguration>();

            // Register Quartz
            var quartz = container.Resolve<IQuartzConfiguration>();
            quartz.Scheduler.JobFactory = new QuartzJobFactory(container);
            quartz.Scheduler.ListenerManager.AddJobListener(container.Resolve<IJobListener>());
        }
    }
}