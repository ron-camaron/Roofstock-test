using MediatR;
using System.Threading;
using System.Threading.Tasks;
using rs_service.Application.Interfaces;

namespace rs_service.Application.Property.Commands.Insert
{
    public class InsertPropertyCommandHandler : IRequestHandler<InsertPropertyCommand, bool>
    {
        private readonly IDatabaseContext _context;

        public InsertPropertyCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(InsertPropertyCommand request, CancellationToken cancellationToken)
        {
            var newProperty = new Domain.Entities.Property
            {
                Id = request.Id,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                State = request.State,
                ZipCode = request.Zip,
                ZipPlus4 = request.ZipPlus4,
                YearBuilt = request.YearBuilt,
                ListPrice = request.ListPrice,
                MonthlyRent = request.MonthlyRent
            };

            await _context.Properties.AddAsync(newProperty);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
