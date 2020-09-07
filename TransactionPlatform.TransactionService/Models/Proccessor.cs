using Quartz;
using System.Threading.Tasks;

namespace TransactionPlatform.TransactionService.Models
{
    public class Proccessor : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var orderProccessor = OrderProccessor.Instance;

            var p1 = orderProccessor.MoveOrdersFromEntryQueueToMainQueue();
            var p2 = Task.Run(() => orderProccessor.MatchOrdersOnFloor());
            var p3 = Task.Run(() => orderProccessor.ProcessTransaction());
            var p4 = orderProccessor.ProcessUnfinishedOrders();

            var tasks = new Task[] { p1, p2, p3, p4 };
            Task.WaitAll(tasks);
            
        }
    }
}