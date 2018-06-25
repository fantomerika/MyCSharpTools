using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class test
    {
        public async void start()
        {
            // First we must get a reference to a scheduler
            ISchedulerFactory sf = new StdSchedulerFactory(); 
            IScheduler sched =await sf.GetScheduler();

            IJobDetail job = JobBuilder.Create<HelloJob>()
              .WithIdentity("job1", "group21")
              .Build();//

            //什么时候开始执行
            DateTime runTime = DateTime.Now;
            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartAt(runTime)
            //.WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever())//无限循环
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
        Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Quartz");
            return null;
        }
    }
}
