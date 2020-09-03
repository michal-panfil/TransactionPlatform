using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace TransactionPlatform.TransactionService.Models
{
 
    internal class OrderProccesorScheduler
    {
        private static readonly object padlock = new object();
        public static OrderProccesorScheduler instance = null;

    private OrderProccesorScheduler()
        {
            instance = new OrderProccesorScheduler();
        }
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
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();
            await scheduler.Start();
            var job = JobBuilder.Create<OrderProccessor>()
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
}