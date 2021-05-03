using rs_service.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using rs_service.Application.Exceptions;

namespace rs_service.Application.Property.Commands.Update
{
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, bool>
    {
        private readonly IDatabaseContext _context;

        public UpdatePropertyCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await _context.Properties.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (property == null)
            {
                throw new NotFoundException(nameof(Property), request.Id);
            }

            property.Address1 = request.Address1;
            property.Address2 = request.Address2;
            property.City = request.City;
            property.State = request.State;
            property.ZipCode = request.Zip;
            property.ZipPlus4 = request.ZipPlus4;
            property.YearBuilt = request.YearBuilt;
            property.ListPrice = request.ListPrice;
            property.MonthlyRent = request.MonthlyRent;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
