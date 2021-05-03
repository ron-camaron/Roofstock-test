using FluentValidation;

namespace rs_service.Application.Property.Commands.Update
{
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).WithMessage("Property Id is not valid.");
        }
    }
}
