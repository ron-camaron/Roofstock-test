using FluentValidation;

namespace rs_service.Application.Property.Commands.Insert
{
    public class InsertPropertyCommandValidator : AbstractValidator<InsertPropertyCommand>
    {
        public InsertPropertyCommandValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).WithMessage("Property Id is not valid.");
        }
    }
}
