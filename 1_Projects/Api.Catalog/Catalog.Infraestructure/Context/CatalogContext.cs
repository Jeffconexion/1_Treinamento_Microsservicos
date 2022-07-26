using Catalog.Core.Entities;
using Catalog.Infraestructure.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infraestructure.Context
{
  public class CatalogContext : ICatalogContext
  {

    private readonly DbSettings _dbSettings;

    public CatalogContext(IOptions<DbSettings> dbSettings)
    {
      _dbSettings = dbSettings.Value;

      var client = new MongoClient(_dbSettings.ConnectionString);
      var database = client.GetDatabase(_dbSettings.DatabaseName);
      Products = database.GetCollection<Product>(_dbSettings.CollectionName);

      CatalogContextSeed.SeedData(Products);
    }

    public IMongoCollection<Product> Products { get; }
  }
}
