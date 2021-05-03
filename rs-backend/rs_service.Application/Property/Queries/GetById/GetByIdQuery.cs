using rs_service.Application.DTOs;
using MediatR;

namespace rs_service.Application.Property.Queries.GetById
{
    public class GetByIdQuery : IRequest<PropertyDto>
    {
        public int Id { get; set; }
    }
}
