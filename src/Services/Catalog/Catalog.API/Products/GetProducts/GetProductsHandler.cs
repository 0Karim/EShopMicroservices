using BuildingBlocks.CQRS;
using Marten.Pagination;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler : 
        IRequestHandler<GetProductsQuery , GetProductsResult>
    {
        private readonly IDocumentSession _session;

        public GetProductsQueryHandler(IDocumentSession documentSession)
        {
            _session = documentSession;
        }

        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _session.Query<Product>()
                .ToPagedListAsync(query.PageNumber ?? 1 , query.PageSize ?? 5 , cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
