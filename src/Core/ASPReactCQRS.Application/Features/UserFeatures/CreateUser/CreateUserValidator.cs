using FluentValidation;

namespace ASPReactCQRS.Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Email).MaximumLength(255).EmailAddress();
            RuleFor(x => x.VendorCode).MaximumLength(6);
            RuleFor(x => x.Company).MaximumLength(255);
        }
    }
}
