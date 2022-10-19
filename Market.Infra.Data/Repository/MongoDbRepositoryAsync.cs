using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Models;
using Market.Domain.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Market.Infra.Data.Repository
{
    public class MongoDbRepositoryAsync<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityAudit
    {
        private readonly IMongoCollection<TEntity> DbCollection;
        private readonly FilterDefinitionBuilder<TEntity> filterBuilder = Builders<TEntity>.Filter;

        public MongoDbRepositoryAsync(IMongoDatabase database, string CollectionName)
        {
            DbCollection = database.GetCollection<TEntity>(CollectionName);
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            FilterDefinition<TEntity> filter = filterBuilder?.Eq(p => id, id);

            return await DbCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec)
        {
            return (IEnumerable<TEntity>)await DbCollection.Find(spec.Criteria).ToListAsync();
        }

        public Task<IEnumerable<TEntity>> GetAllSoftDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if(entity is null)
            {
                throw new NotImplementedException();
            }
            FilterDefinition<TEntity> filter = filterBuilder?.Eq(itemList => itemList.Id, entity.Id);

            await DbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<TEntity> filter = filterBuilder?.Eq(itemlist => itemlist.Id,id);

            await DbCollection.DeleteOneAsync(filter);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(TEntity entity)
        {
            if(entity is null)
            {
                throw new NullReferenceException();
            }
            await DbCollection.InsertOneAsync(entity);
        }
    }
}
