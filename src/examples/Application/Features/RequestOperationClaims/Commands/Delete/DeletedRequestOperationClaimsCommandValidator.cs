using FluentValidation;

namespace Application.Features.RequestOperationClaims.Commands.Delete;

public class DeleteRequestOperationClaimsCommandValidator : AbstractValidator<DeleteRequestOperationClaimsCommand>
{
    public DeleteRequestOperationClaimsCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}