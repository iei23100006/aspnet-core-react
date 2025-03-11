using FluentValidation;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Delete[FTName]
{
    public sealed class Delete[FTName]Validator : AbstractValidator<Delete[FTName]Request>
    {
        public Delete[FTName]Validator() 
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id doesn't exist in database.");
        }
    }
}
