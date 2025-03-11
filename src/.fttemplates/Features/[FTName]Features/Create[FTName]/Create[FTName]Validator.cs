using FluentValidation;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Create[FTName]
{
    public sealed class Create[FTName]Validator : AbstractValidator<Create[FTName]Request>
    {
        public Create[FTName]Validator()
        {
            RuleFor(x => x.[FTName]Name)
                .NotEmpty();
        }
    }
}
