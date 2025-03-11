using FluentValidation;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity
{
    public sealed class GetActivityValidator : AbstractValidator<GetActivityRequest>
    {
        public GetActivityValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
