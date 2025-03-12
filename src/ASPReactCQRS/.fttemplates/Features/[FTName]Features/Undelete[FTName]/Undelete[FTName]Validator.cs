using FluentValidation;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Undelete[FTName]
{
    public sealed class Undelete[FTName]Validator : AbstractValidator<Undelete[FTName]Request>
    {
        public Undelete[FTName]Validator() 
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id doesn't exist in database.");
        }
    }
}
