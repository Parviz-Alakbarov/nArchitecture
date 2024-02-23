using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListModelByDynamicQuery : IRequest<GetListResponse<GetListModelByDynamicDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, GetListResponse<GetListModelByDynamicDto>>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _repository;
        public GetListModelByDynamicQueryHandler(IMapper mapper, IModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetListResponse<GetListModelByDynamicDto>> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _repository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
                include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
               );
            var response = _mapper.Map<GetListResponse<GetListModelByDynamicDto>>(models);
            return response;
        }
    }
}
