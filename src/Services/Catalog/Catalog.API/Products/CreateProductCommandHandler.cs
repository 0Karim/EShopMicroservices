using MediatR;
using System.Threading;

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

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create Product entity from command object
            //save to database
            //return CreateProductResult result

            try
            {
                var product = new Product
                {
                    Name = command.Name,
                    Category = command.Category,
                    Description = command.Description,
                    ImageFile = command.ImageFile,
                    Price = command.Price
                };

                // TODO
                //save to database
                //return result
                _documentSession.Store(product);
                await _documentSession.SaveChangesAsync(cancellationToken);

                return new CreateProductResult(Guid.NewGuid());
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
