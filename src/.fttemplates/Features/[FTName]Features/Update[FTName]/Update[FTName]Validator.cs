using FluentValidation;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Update[FTName]
{
    public sealed class Update[FTName]Validator : AbstractValidator<Update[FTName]Request>
    {
        public Update[FTName]Validator()
        {
            RuleFor(x => x.[FTName]Body.Id).GreaterThan(0).WithMessage("Id doesn't exist in database");
            RuleFor(x => x.[FTName]Body.[FTName]Name).NotEmpty().WithMessage("[FTName] Name cannot be Empty!");
        }
    }
}
