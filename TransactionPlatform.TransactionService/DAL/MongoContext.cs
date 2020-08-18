using MongoDB.Driver;
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
    public class MongoContext
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
  
        public  void AddOrderToDb(Order order) {
            var client = new MongoClient();
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");
            collection.InsertOne(order);
        }

        public async Task<UpdateResult> ChangeStatus(Order order, OrderStatus status) {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");

            var filter = Builders<Order>.Filter.Eq("Id", order.Id);
            var update = Builders<Order>.Update.Set("status", status);
            var resultTsk = collection.UpdateOneAsync(filter, update);
            return await resultTsk;
        }
        public async Task<Order> GetOrderFromDb(Guid id)
        {
            var client = new MongoClient(ConnectionString.ToString());
            var db = client.GetDatabase("TransactionMongoDB");
            var collection = db.GetCollection<Order>("Orders");


            var resultTsk = collection.FindAsync(o => o.Id == id);
            var result = await resultTsk;
            return result.FirstOrDefault();
        }
    }
}