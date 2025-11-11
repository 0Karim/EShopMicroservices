using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery (Guid Id) : IQuery<GetProductByIdQueryResult>;

    public record GetProductByIdQueryResult(Product Product);

    internal class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IDocumentSession _session;

        public GetProductByIdHandler(IDocumentSession session)
        {
            _session = session;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _session.LoadAsync<Product>(query.Id);
            if (product == null)
                throw new ProductNotFoundException(query.Id);

            return new GetProductByIdQueryResult(product);
        }
    }
}
