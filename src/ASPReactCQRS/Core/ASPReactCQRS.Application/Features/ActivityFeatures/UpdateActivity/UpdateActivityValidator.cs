using FluentValidation;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UpdateActivity
{
    public sealed class UpdateActivityValidator : AbstractValidator<UpdateActivityRequest>
    {
        public UpdateActivityValidator()
        {
            RuleFor(x => x.ActivityBody.Id).GreaterThan(0).WithMessage("Id doesn't exist in database");
            RuleFor(x => x.ActivityBody.ActivityName).NotEmpty().WithMessage("Activity Name cannot be Empty!");
        }
    }
}
