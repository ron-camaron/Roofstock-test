using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using rs_service.Application.DTOs;
using rs_service.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rs_service.Application.Property.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ICollection<PropertyDto>>
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<PropertyDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var properties = await _context.Properties
                .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return properties;
        }
    }
}
