using FluentValidation;

namespace Application.Features.RequestOperationClaims.Commands.Create;

public class CreateRequestOperationClaimsCommandValidator : AbstractValidator<CreateRequestOperationClaimsCommand>
{
    public CreateRequestOperationClaimsCommandValidator()
    {
        RuleFor(c => c.RequestConfigId).NotEmpty();
        RuleFor(c => c.OperationClaimId).NotEmpty();
    }
}