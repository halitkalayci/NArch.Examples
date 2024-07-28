using FluentValidation;

namespace Application.Features.RequestConfigs.Commands.Create;

public class CreateRequestConfigCommandValidator : AbstractValidator<CreateRequestConfigCommand>
{
    public CreateRequestConfigCommandValidator()
    {
        RuleFor(c => c.RequestName).NotEmpty();
    }
}