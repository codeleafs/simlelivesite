using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using System.Threading;

namespace Simle.System.Job
{
    class SyncData
    {
        public void Run()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            scheduler.Start();

            IJobDetail job = JobBuilder.Create<SimpleJob>()
                 .WithIdentity("JobName", "GroupName")
                 .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TriggerName", "GroupName")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);

            Thread.Sleep(10000);
            scheduler.Shutdown();
        }
    }

    class SimpleJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("test");
        }
    }
}
