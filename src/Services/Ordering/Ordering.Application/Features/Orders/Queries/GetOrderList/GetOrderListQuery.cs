using MediatR;
using Ordering.Application.EntityDtos;
using System.Collections.Generic;

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