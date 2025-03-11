using FluentValidation;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s;

namespace ASPReactCQRS.Application.Features.LabelTemplateFeatures.Get[FTName]s
{
    public sealed class Get[FTName]sValidator : AbstractValidator<Get[FTName]sRequest>
    {
        public Get[FTName]sValidator() 
        {
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PageSize).NotEmpty();
        }
    }
}
