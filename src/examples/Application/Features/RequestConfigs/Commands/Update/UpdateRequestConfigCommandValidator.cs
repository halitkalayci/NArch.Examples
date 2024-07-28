using FluentValidation;

namespace Application.Features.RequestConfigs.Commands.Update;

public class UpdateRequestConfigCommandValidator : AbstractValidator<UpdateRequestConfigCommand>
{
    public UpdateRequestConfigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequestName).NotEmpty();
    }
}