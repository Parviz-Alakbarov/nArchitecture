using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeletedBrandResponse> , ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string? CacheKey => null;

    public bool BypassCache => default;

    public string? CacheGroupKey => "GetBrands";

    public class DeletedBrandCommandHandler:IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _repository;

        public DeletedBrandCommandHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _repository.GetAsync(predicate:b=>b.Id== request.Id, cancellationToken:cancellationToken);
            await _repository.DeleteAsync(brand);
            DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
            return response;
        }
    }
}
