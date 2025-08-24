namespace CatalogApi.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        /// <summary>
        ///     Handles the creation of a new product based on the provided command.
        /// </summary>
        ///     <param name="command">The command containing the product details.</param>
        ///     <param name="cancellationToken">The cancellation token for the operation.</param>
        ///     <returns>A task containing the result of the product creation, including the ID of the created product.</returns>
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Imagefile = command.ImageFile,
            Price = command.Price,
        };
        //save to db
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //return result
        return new CreateProductResult(product.Id);
    }
}
