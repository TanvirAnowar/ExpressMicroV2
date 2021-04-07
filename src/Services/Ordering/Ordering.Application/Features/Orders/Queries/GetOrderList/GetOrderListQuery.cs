using System.Collections.Generic;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.EntityDtos;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
        public string UserName { get; set; }

   
        public GetOrderListQuery(string userName)
        {
            UserName = userName;
        }
    }
}