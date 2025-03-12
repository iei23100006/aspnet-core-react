using FluentValidation;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.CreateActivity
{
    public sealed class CreateActivityValidator : AbstractValidator<CreateActivityRequest>
    {
        public CreateActivityValidator()
        {
            RuleFor(x => x.ActivityName)
                .NotEmpty();
        }
    }
}
