using Market.Domain.Models;
using Market.Domain.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Market.Infra.Repository
{
    public class MongoDbAsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : IAggregate
    {
        private readonly IMongoCollection<TEntity> DbCollection;
        private readonly FilterDefinitionBuilder<TEntity> filterBuilder = Builders<TEntity>.Filter;

        public MongoDbAsyncRepository(IMongoDatabase database, string CollectionName)
        {
            DbCollection = database.GetCollection<TEntity>(CollectionName);
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var filter = filterBuilder.Eq(p => p.Id, id);

            return await DbCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            if (obj is null) {
                throw new NotImplementedException();
            }
            var filter = filterBuilder?.Eq(itemList => itemList.Id, obj.Id);

            await DbCollection.ReplaceOneAsync(filter, obj);
        }

        public async Task RemoveAsync(Guid id)
        {
            var filter = filterBuilder?.Eq(itemlist => itemlist.Id, id);

            await DbCollection.DeleteOneAsync(filter);
        }
        public async Task CreateAsync(TEntity obj)
        {
            if (obj is null) {
                return ;
            }
            await DbCollection.InsertOneAsync(obj);
        }
    }
}