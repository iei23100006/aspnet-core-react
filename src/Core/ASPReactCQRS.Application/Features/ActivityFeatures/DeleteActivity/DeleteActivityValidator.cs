using FluentValidation;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.DeleteActivity
{
    public sealed class DeleteActivityValidator : AbstractValidator<DeleteActivityRequest>
    {
        public DeleteActivityValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id doesn't exist in database.");
        }
    }
}
