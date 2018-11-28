using System.Threading.Tasks;
using Quartz;

namespace TopShelfQuartz.Quartz.Jobs
{
    public class MediumJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(1000);
        }
    }
}