using catalog.api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.Data
{
   public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }  
    }
}
