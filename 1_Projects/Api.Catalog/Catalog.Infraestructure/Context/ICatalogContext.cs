using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infraestructure.Context
{
  public interface ICatalogContext
  {
    IMongoCollection<Product> Products { get; }
  }
}
