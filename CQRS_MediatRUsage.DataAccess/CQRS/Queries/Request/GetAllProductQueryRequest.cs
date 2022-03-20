using CQRS_MediatRUsage.DataAccess.CQRS.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatRUsage.DataAccess.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
