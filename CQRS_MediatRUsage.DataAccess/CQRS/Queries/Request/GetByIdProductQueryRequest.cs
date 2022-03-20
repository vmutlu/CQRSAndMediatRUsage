using CQRS_MediatRUsage.DataAccess.CQRS.Queries.Response;
using MediatR;
using System;

namespace CQRS_MediatRUsage.DataAccess.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
