using FluentValidation;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UndeleteActivity
{
    public sealed class UndeleteActivityValidator : AbstractValidator<UndeleteActivityRequest>
    {
        public UndeleteActivityValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id doesn't exist in database.");
        }
    }
}
