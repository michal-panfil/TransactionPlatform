using System;
using TransactionPlatform.TransactionService.Models;

namespace TransactionPlatform.TransactionService.DAL
{
    public interface IDataContext
    {
        void AddOrderToDb(Order order);
        long ChangeStatus(Guid orderId, OrderStatus status);
        Order GetOrderFromDb(Guid id);
    }
}