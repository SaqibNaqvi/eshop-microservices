
namespace CatalogApi.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);
internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
