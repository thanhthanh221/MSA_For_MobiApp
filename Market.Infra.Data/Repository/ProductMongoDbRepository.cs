using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Interface;
using Market.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Market.Infra.Data.Repository
{
    public class ProductMongoDbRepository : IAsyncProductRepository
    {
        
        private readonly IMongoCollection<Product> DbCollection;
        private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;

        public ProductMongoDbRepository(IMongoDatabase database, string CollectionName)
        {
            DbCollection = database.GetCollection<Product>(CollectionName);
        }

        public async Task Add(Product entity)
        {
            if(entity == null) 
            { 
                throw new ArgumentNullException(nameof(entity));
            }
            await DbCollection.InsertOneAsync(entity);
                
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            FilterDefinition<Product> filter = filterBuilder?.Eq(p => id, id);

            return await DbCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await DbCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(ISpecification<Product> spec)
        {
            return await DbCollection.Find(spec.Criteria).ToListAsync();
        }

        public Task<IEnumerable<Product>> GetAllSoftDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entity)
        {
            if(entity is null)
            {
                throw new NotImplementedException();
            }
            FilterDefinition<Product> filter = filterBuilder?.Eq(itemList => itemList.Id, entity.Id);

            await DbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Product> filter = filterBuilder?.Eq(itemlist => itemlist.Id,id);

            await DbCollection.DeleteOneAsync(filter);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
