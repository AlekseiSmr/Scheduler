using System.Threading.Tasks;
using Quartz;

namespace TopShelfQuartz.Quartz.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(1000);
        }
    }
}