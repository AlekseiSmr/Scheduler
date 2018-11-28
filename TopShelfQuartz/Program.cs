using System;
using System.Collections.Generic;
using System.Reflection;
using Stashbox;
using Topshelf;
using TopShelfQuartz.Quartz.Interfaces;

namespace TopShelfQuartz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new StashboxContainer(configurator =>
            {
                configurator.WithDisposableTransientTracking();
            });

            // Scan assemblies by ICompositionRoot
            container.ComposeAssemblies(new List<Assembly>
            {
                Assembly.GetExecutingAssembly()
            });

            var rc = HostFactory.Run(x =>
            {
                x.Service<IQuartzScheduleJobManager>(s =>
                {
                    s.ConstructUsing(name => container.Resolve<IQuartzScheduleJobManager>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Stuff");
                x.SetServiceName("Stuff");
            });

            var exitCode = (int) Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}