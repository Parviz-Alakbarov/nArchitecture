using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandDto>>, ILoggableRequest, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetBrands";

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery , GetListResponse<GetListBrandDto>>
    {
        public IBrandRepository _repository { get; }
        public IMapper _mapper { get; }
        public GetListBrandQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBrandDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            Paginate<Brand> brands = await _repository.GetListAsync(index:request.PageRequest.PageIndex, size:request.PageRequest.PageSize, cancellationToken:cancellationToken);
            GetListResponse<GetListBrandDto> response = _mapper.Map<GetListResponse<GetListBrandDto>>(brands);
            return response;
        }
    }
}
