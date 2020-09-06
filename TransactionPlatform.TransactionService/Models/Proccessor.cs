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

            await p1;
            await p2;
            await p3;
            await p4;
        }
    }
}