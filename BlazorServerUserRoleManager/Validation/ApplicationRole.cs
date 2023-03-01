using FluentValidation;

namespace BlazorServerUserRoleManager.Validation
{
    public class ApplicationRole : AbstractValidator<Entities.ApplicationRole>
    {
        public ApplicationRole()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Badge).MaximumLength(6).WithMessage("Badge must be 6 characters or less");
        }
    }
}