using AutoMapper;
using Hng.Application.Features.Products.Dtos;
using Hng.Application.Features.Products.Queries;
using Hng.Application.Shared.Dtos;
using Hng.Domain.Entities;
using Hng.Infrastructure.Repository.Interface;
using MediatR;

namespace Hng.Application.Features.Products.Handlers
{
    public class GetUserProductsQueryHandler : IRequestHandler<GetUserProductsQuery, PagedListDto<ProductDto>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetUserProductsQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedListDto<ProductDto>> Handle(GetUserProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetBySpec(
			o => o.UserId == request.productsQueryParameters.UserId);

			var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);
            var productsResult = PagedListDto<ProductDto>.ToPagedList(mappedProducts, request.productsQueryParameters.PageNumber, request.productsQueryParameters.PageSize);

            return productsResult;
        }
    }
}
