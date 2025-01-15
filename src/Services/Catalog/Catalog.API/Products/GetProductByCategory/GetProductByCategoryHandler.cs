using BuildingBlocks.CQRS;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHandler : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        private readonly IDocumentSession session;

        public GetProductByCategoryQueryHandler(IDocumentSession documentSession)
        {
            session = documentSession;
        }

        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                        .Where(p => p.Category.Contains(query.Category))
                        .ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(products);
        }
    }
}
