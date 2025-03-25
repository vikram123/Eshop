namespace Catlog.Api.Products.CreateProduct;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Catlog.Api.Models;
using Marten;

public record CreateProductCommand(string Name, List<string> Category, decimal Price, String Description, string imagefile)
 : ICommand<CreateproductResult>;
public record CreateproductResult(Guid Id);
internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateproductResult>
{
    public async Task<CreateproductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var Prouduct = new Product()
        {
            Name= command.Name,
            Price= command.Price,
            Description= command.Description,
            Category= command.Category,
            ImageFile= command.imagefile,
        };
        session.Store(Prouduct);
        await session.SaveChangesAsync(cancellationToken);
        return new  CreateproductResult(Prouduct.Id);
    }
}
