using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class test
    {
        public async void start()
        {
            IScheduler sched = await new StdSchedulerFactory().GetScheduler();

            IJobDetail job = JobBuilder.Create<HelloJob>()
              .WithIdentity("job1")
              .Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1")
            .StartAt(DateTime.Now)
            .WithCronSchedule("0/3 * * * * ?")
            .Build();

            await sched.ScheduleJob(job, trigger);
            //启动任务
            await sched.Start();
        }
    }

    /// <summary>
    /// This is just a simple job that says "Hello" to the world.
    /// </summary>
    /// <author>Bill Kratzer</author>
    /// <author>Marko Lahma (.NET)</author>
    public class HelloJob : IJob
    {
        /// <summary> 
        /// Called by the <see cref="IScheduler" /> when a
        /// <see cref="ITrigger" /> fires that is associated with
        /// the <see cref="IJob" />.
        /// </summary>
        async Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Quartz");
        }
    }
}
