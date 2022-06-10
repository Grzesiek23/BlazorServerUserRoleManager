
using FluentValidation;

namespace BlazorServerUserRoleManager.Validation
{
    public class ApplicationUser : AbstractValidator<Entities.ApplicationUser>
    {
        public ApplicationUser()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email)).WithMessage("Invalid email address");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            
            RuleFor(p => p.PasswordHash).NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").When(x => !x.PasswordHash.Equals("*********")).WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}