using BuildingBlocks.CQRS;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }

    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand , DeleteProductResult>
    {
        private readonly IDocumentSession _documentSession;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IDocumentSession documentSession , ILogger<DeleteProductCommandHandler> logger)
        {
            _documentSession = documentSession;
            _logger = logger;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);
            _documentSession.Delete<Product>(command.Id);
            await _documentSession.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
