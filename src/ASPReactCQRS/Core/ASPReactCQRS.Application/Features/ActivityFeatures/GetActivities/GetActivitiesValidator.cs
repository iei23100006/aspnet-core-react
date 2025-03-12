using FluentValidation;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities;

namespace ASPReactCQRS.Application.Features.LabelTemplateFeatures.GetActivities
{
    public sealed class GetActivitiesValidator : AbstractValidator<GetActivitiesRequest>
    {
        public GetActivitiesValidator() 
        {
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PageSize).NotEmpty();
        }
    }
}
