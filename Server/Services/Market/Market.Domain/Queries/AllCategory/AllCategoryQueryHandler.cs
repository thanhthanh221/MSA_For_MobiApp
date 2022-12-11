using CatchingRedis.Services;
using Market.Domain.Interface;
using Market.Domain.Model;
using Newtonsoft.Json;
using MediatR;

namespace Market.Domain.Queries.AllCategory
{
    public class AllCategoryQueryHandler : IRequestHandler<AllCategoryQuery, List<Category>>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IReposeCacheService reposeCache;
        private readonly IMediator mediator;

        public AllCategoryQueryHandler(
            IAsyncRepository<Category> categoryRepository, IReposeCacheService reposeCache, IMediator mediator)
        {
            this.categoryRepository = categoryRepository;
            this.reposeCache = reposeCache;
            this.mediator = mediator;
        }

        public async Task<List<Category>> Handle(AllCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = new();
            var allCategoryInCatche = await reposeCache.GetAllCacheReponseAsync("GetCategory_");

            if (allCategoryInCatche.Count != 0) {
                foreach (var cate in allCategoryInCatche) {
                    categories.Add(JsonConvert.DeserializeObject<Category>(cate));
                }
                return categories;
            }

            categories = (await categoryRepository.GetAllAsync()).ToList();

            // Update Catche
            foreach (var cate in categories)
            {
                
            }

            return categories;



        }
    }
}