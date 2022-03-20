using CQRS_MediatRUsage.DataAccess.CQRS.Commands.Request;
using CQRS_MediatRUsage.DataAccess.CQRS.Commands.Response;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatRUsage.DataAccess.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = CQRS_MediatRUsage.DataAccess.Context.AppContext.Products.FirstOrDefault(p => p.Id == request.Id);
            CQRS_MediatRUsage.DataAccess.Context.AppContext.Products.Remove(deleteProduct);
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
