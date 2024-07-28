using FluentValidation;

namespace Application.Features.RequestConfigs.Commands.Delete;

public class DeleteRequestConfigCommandValidator : AbstractValidator<DeleteRequestConfigCommand>
{
    public DeleteRequestConfigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}