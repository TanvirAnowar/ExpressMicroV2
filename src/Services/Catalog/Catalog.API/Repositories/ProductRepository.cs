using System;
using Catalog.API.Data;
using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext context; 

        public ProductRepository(ICatalogContext catalogContext)
        {
            context = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.Find(p => true).ToListAsync();
        }
        public async Task<Product> GetProduct(string id)
        {
            return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await context.Products.Find(filter).ToListAsync();

        }
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await context.Products.Find(filter).ToListAsync();
        }
        public async Task CreateProduct(Product product)
        {
            await context.Products.InsertOneAsync(product);
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            var updateStatus = await context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

            return (updateStatus.IsAcknowledged && updateStatus.ModifiedCount > 0) ? true : false;
                
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            
            var deleteStatus = await context.Products.DeleteOneAsync(filter);

            return (deleteStatus.IsAcknowledged && deleteStatus.DeletedCount > 0) ? true : false;

        }





    }
}