﻿using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.TransactionService.Models;
using System.Web.Configuration;
using System.IO;

namespace TransactionPlatform.TransactionService.DAL
{
    public class MongoContext : IDBContext
    {
        private static string connection = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
        private string ConnectionString = connection;

        public async Task AddOrderToDb(Order order)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("ActiveOrders");
            await collection.InsertOneAsync(order);
        }

        public async Task<UpdateResult> ChangeStatus(Order order, OrderStatus status)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("ActiveOrders");

            var filter = Builders<Order>.Filter.Eq("Id", order.Id);
            var update = Builders<Order>.Update.Set("status", status);
            var resultTsk = collection.UpdateOneAsync(filter, update);
            return await resultTsk;
        }
        public async Task<Order> GetOrderFromDb(Guid id)
        {
            var client = new MongoClient(ConnectionString.ToString());
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("ActiveOrders");


            var resultTsk = collection.FindAsync(o => o.Id == id);
            var result = await resultTsk;
            return result.FirstOrDefault();
        }

        public async Task<Order> GetOrderByOrderFormId(Guid orderFromId)
        {
            var client = new MongoClient(ConnectionString.ToString());
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("ActiveOrders");


            var resultTsk = collection.FindAsync(o => o.OrderForm.Id == orderFromId);
            var result = await resultTsk;
            return result.FirstOrDefault();
        }

        public async Task AddTransactions(List<Transaction> transactions)
        {
            var client = new MongoClient(ConnectionString.ToString());
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Transaction>("Transactions");

            await collection.InsertManyAsync(transactions);
        }
        public async Task MoveOrder(List<Order> orders)
        {
            var client = new MongoClient(ConnectionString.ToString());
            var db = client.GetDatabase("TransactionMongoDB");
            var collectionActive = db.GetCollection<Order>("ActiveOrders");
            var collectionFinished = db.GetCollection<Order>("FinishedOrders");

            foreach (var order in orders)
            {
                await collectionActive.DeleteOneAsync<Order>(o => o.Id == order.Id);
            }
            
            await collectionFinished.InsertManyAsync(orders);    
        }
    }
}