using FluentValidation;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]
{
    public sealed class Get[FTName]Validator : AbstractValidator<Get[FTName]Request>
    {
        public Get[FTName]Validator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
