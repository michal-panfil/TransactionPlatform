using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace TransactionPlatform.TransactionService.Models
{
    internal class OrderProccesorScheduler
    {
        private static readonly object padlock = new object();
        private static OrderProccesorScheduler instance = null;
        private static bool isRunning = false;

        public static OrderProccesorScheduler Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new OrderProccesorScheduler();
                    }
                    return instance;
                }
            }
        }

        public async Task Schedule()
        {
            try
            {
                if (!isRunning)
                {
                    isRunning = true;
                    var factory = new StdSchedulerFactory();
                    var scheduler = await factory.GetScheduler();
                    await scheduler.Start();
                    var job = JobBuilder.Create<Proccessor>()
                        .WithIdentity("procesor", "main")
                        .Build();

                    var trigger = TriggerBuilder.Create()
                        .WithIdentity("trigger", "main")
                        .StartNow()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(5)
                                                .RepeatForever())
                        .Build();

                    await scheduler.ScheduleJob(job, trigger);
                }
            }
            catch (Exception)
            {
                isRunning = false;
            }
        }
    }
}