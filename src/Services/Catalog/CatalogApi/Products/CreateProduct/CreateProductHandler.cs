using BuildingBlocks.CQRS;
using CatalogApi.Model;
using MediatR;
using System.Windows.Input;

namespace CatalogApi.Products.CreateProduct;

public record CreateProductCommand
    (string Name,List<string> Category,string  Description,string ImageFile,decimal Price)
: ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Imagefile = command.ImageFile,
            Price = command.Price
        };


        return new CreateProductResult(Guid.NewGuid());
     
    }
}
