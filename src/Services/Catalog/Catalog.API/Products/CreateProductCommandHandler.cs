
namespace Catalog.API.Products
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _documentSession;

        public CreateProductCommandHandler(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Category = request.Category,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price
            };

            _documentSession.Store(product);
            await _documentSession.SaveChangesAsync(cancellationToken);


            return new CreateProductResult(product.Id);
        }
    }
}
