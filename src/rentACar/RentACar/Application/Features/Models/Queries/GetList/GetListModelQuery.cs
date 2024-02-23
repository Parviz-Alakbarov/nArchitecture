using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery : IRequest<GetListResponse<GetListModelDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelDto>>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _repository;
        public GetListModelQueryHandler(IMapper mapper, IModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetListResponse<GetListModelDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _repository.GetListAsync(
                include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize
                );
            var response = _mapper.Map<GetListResponse<GetListModelDto>>(models);
            return response;
        }
    }
}
