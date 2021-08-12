using catalog.api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString")) ;
            var database =  client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            this.Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; } 
    }
}
