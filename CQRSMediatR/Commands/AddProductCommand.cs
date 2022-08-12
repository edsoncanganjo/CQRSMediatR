using MediatR;

namespace CQRSMediatR.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}
