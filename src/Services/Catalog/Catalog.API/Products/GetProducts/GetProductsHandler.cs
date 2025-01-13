using BuildingBlocks.CQRS;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler : 
        IRequestHandler<GetProductsQuery , GetProductsResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IDocumentSession documentSession, ILogger<GetProductsQueryHandler> logger)
        {
            _session = documentSession;
            _logger = logger;
        }

        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", request);
            var products = await _session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}
