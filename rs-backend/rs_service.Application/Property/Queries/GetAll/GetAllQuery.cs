using MediatR;
using rs_service.Application.DTOs;
using System.Collections.Generic;

namespace rs_service.Application.Property.Queries.GetAll
{
    public class GetAllQuery : IRequest<ICollection<PropertyDto>> { }
}
