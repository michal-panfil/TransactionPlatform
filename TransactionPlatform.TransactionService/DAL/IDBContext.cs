using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionPlatform.TransactionService.Models;

namespace TransactionPlatform.TransactionService.DAL
{
    public interface IDBContext
    {
        void AddOrderToDb(Order order);
        Task<UpdateResult> ChangeStatus(Order order, OrderStatus status);
        Task<Order> GetOrderByOrderFormId(Guid orderFromId);
        Task<Order> GetOrderFromDb(Guid id);
        void AddTransactions(List<Transaction> matches);
        void MoveOrder(List<Order> orders);
    }
}