using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class JobHelper
    {
        private static IScheduler scheduler;
        public JobHelper()
        {
            init();
        }
        private static async Task init()
        {
            scheduler = await new StdSchedulerFactory().GetScheduler();
        }
        #region 触发器管理
        /// <summary>
        /// 创建触发器
        /// </summary>
        /// <param name="CronCode">Cron表达式</param>
        /// <param name="name">标识名称</param>
        public ITrigger createTrigger(string cronCode, string name, string groupName = null)
        {
            var trigerBuilder = TriggerBuilder.Create();
            if (groupName == null)
                trigerBuilder = trigerBuilder.WithIdentity(name);
            else
                trigerBuilder = trigerBuilder.WithIdentity(name, groupName);
            return trigerBuilder
           .StartAt(DateTime.Now)
           .WithCronSchedule(cronCode)
           .Build();
        }
        #endregion

        #region 工作管理
        /// <summary>
        ///  增加一个工作
        /// </summary>
        /// <typeparam name="T">IJob派生类</typeparam>
        /// <param name="trigger">触发器</param>
        /// <param name="name">名称</param>
        /// <param name="groupName">组名</param>
        /// <param name="isStart">是否开启任务</param>
        /// <returns></returns>
        public async Task addJob<T>(ITrigger trigger, string name, string groupName = null,
            bool isStart = true) where T : IJob
        {
            var jobBuilder = JobBuilder.Create<T>();
            if (groupName == null)
                jobBuilder.WithIdentity(name);
            else
                jobBuilder.WithIdentity(name, groupName);
            await scheduler.ScheduleJob(jobBuilder.Build(), trigger);
            if (isStart)
                await scheduler.Start();
        }

        /// <summary>
        /// 获取工作列表
        /// </summary>
        /// <param name="isExecuting"></param>
        public async void JobList(bool isExecuting = false)
        {
            var jobGroups = await scheduler.GetJobGroupNames();
            foreach (var Groupitem in jobGroups)
            {
                var jobKeys = await scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(Groupitem));
                foreach (var jobKeyItem in jobKeys)
                {
                    var jobInfo = await scheduler.GetJobDetail(jobKeyItem);
                }
            }
        }

        /// <summary>
        /// 找到工作key
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="groupName">组名</param>
        /// <returns></returns>
        public async Task<JobKey> FindJob(string name, string groupName = "DEFAULT")
        {
            var jobKeys = await scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName));
            foreach (var jobKeyItem in jobKeys)
            {
                if (jobKeyItem.Name == name)
                    return jobKeyItem;
            }
            return null;
        }

        /// <summary>
        /// 暂停工作
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="groupName">组名</param>
        public async void PauseJob(JobKey jKey)
        {
            await scheduler.PauseJob(jKey);
        }
        #endregion
    }
}
