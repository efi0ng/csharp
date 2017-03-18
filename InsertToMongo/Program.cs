using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;

namespace InsertToMongo
{
   internal class Program
   {
      protected static IMongoClient _client;
      protected static IMongoDatabase _database;
      protected static string _sourceDir = @"C:\src\python\gatherperfdata\jcv_test\subset";

      public static void Main(string[] args)
      {
         _client = new MongoClient();
         _database = _client.GetDatabase("test");
         var collection = _database.GetCollection<BsonDocument>("run1");
 
         var files = Directory.GetFiles(_sourceDir);
         foreach (var file in files)
         {
            string text = File.ReadAllText(file, System.Text.Encoding.UTF8);
            var doc = BsonDocument.Parse(text);
            collection.InsertOne(doc);
         }

      }
   }
}