using Hng.Application.Features.Products.Dtos;
using Hng.Application.Features.Subscriptions.Dtos.Requests;
using Hng.Application.Features.Subscriptions.Dtos.Responses;
using Hng.Application.Shared.Dtos;
using MediatR;

namespace Hng.Application.Features.Products.Queries
{
    public class GetUserProductsQuery : IRequest<PagedListDto<ProductDto>>
    {
        public GetUserProductsQuery(GetUserProductsQueryParameters parameters)
        {
            productsQueryParameters = parameters;
        }

        public GetUserProductsQueryParameters productsQueryParameters { get; set; }
    }
}
