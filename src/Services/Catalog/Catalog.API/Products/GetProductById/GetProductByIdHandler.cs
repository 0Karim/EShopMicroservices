using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery (Guid Id) : IQuery<GetProductByIdQueryResult>;

    public record GetProductByIdQueryResult(Product product);

    internal class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly ILogger<GetProductByIdHandler> _logger;
        private readonly IDocumentSession _session;

        public GetProductByIdHandler(ILogger<GetProductByIdHandler> logger , IDocumentSession session)
        {
            _logger = logger;
            _session = session;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);
            var product = await _session.LoadAsync<Product>(query.Id);
            if (product == null)
                throw new ProductNotFoundException(query.Id);

            return new GetProductByIdQueryResult(product);
        }
    }
}
