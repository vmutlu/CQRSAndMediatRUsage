using CQRS_MediatRUsage.DataAccess.CQRS.Commands.Request;
using CQRS_MediatRUsage.DataAccess.CQRS.Commands.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatRUsage.DataAccess.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            CQRS_MediatRUsage.DataAccess.Context.AppContext.Products.Add(new()
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            });
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = id
            };
        }
    }
}
