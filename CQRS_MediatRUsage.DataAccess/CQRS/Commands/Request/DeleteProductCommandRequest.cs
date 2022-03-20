using CQRS_MediatRUsage.DataAccess.CQRS.Commands.Response;
using MediatR;
using System;

namespace CQRS_MediatRUsage.DataAccess.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
