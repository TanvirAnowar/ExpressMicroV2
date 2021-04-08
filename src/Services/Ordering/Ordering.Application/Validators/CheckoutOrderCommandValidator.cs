using FluentValidation;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.Application.Validators
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty()
                .WithMessage("UserName can not be empty.")
                .NotNull()
                .MaximumLength(50).WithMessage("Username should be under 50 characters.");

            RuleFor(p => p.EmailAddress).NotEmpty()
                .WithMessage("Email can not be empty.")
                .NotNull();

            RuleFor(p => p.TotalPrice).NotEmpty()
                .WithMessage("Total price can not be empty.")
                .NotNull()
                .GreaterThan(0).WithMessage("Total price should be greater than zero.");
        }
    }
}
