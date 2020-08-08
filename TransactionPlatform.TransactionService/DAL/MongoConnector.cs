using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TransactionPlatform.TransactionService.Models;

namespace TransactionPlatform.TransactionService.DAL
{
    public class MongoConnector
    {
        private string ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false";

        public  void AddOrderToDb(Order order) {
           
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");

            collection.InsertOne(order);
        }

        public async Task ChangeStatus(Order order, OrderStatus status) {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");

            var filter = Builders<Order>.Filter.Eq("Id", order.Id);
            var update = Builders<Order>.Update.Set("status", status);
            var result = collection.UpdateOne(filter, update);
        }
        public Order GetOrderFromDb(Guid id)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");


            var order = collection.Find(o => o.Id == id).FirstOrDefault(); ;
            return order;

        }
    }
}