using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.TransactionService.Models;

namespace TransactionPlatform.TransactionService.DAL
{
    public interface IDBContext
    {
        Task AddOrderToDb(Order order);
        Task<UpdateResult> ChangeStatus(Order order, OrderStatus status);
        Task<Order> GetOrderByOrderFormId(Guid orderFromId);
        Task<Order> GetOrderFromDb(Guid id);
        Task AddTransactions(List<Transaction> matches);
        Task MoveOrder(List<Order> orders);
    }
}