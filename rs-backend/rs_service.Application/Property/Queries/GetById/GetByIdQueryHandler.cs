using MediatR;
using System.Threading;
using System.Threading.Tasks;
using rs_service.Application.Interfaces;
using rs_service.Application.DTOs;
using AutoMapper;
using rs_service.Application.Exceptions;

namespace rs_service.Application.Property.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, PropertyDto>
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var property = await _context.Properties.FindAsync(request.Id);

            if (property == null)
            {
                return null;
            }

            return _mapper.Map<PropertyDto>(property);
        }
    }
}
