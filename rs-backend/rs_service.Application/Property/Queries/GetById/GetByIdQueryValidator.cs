using FluentValidation;

namespace rs_service.Application.Property.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(vm => vm.Id).NotEmpty().WithMessage("Property Id is required");
        }
    }
}
