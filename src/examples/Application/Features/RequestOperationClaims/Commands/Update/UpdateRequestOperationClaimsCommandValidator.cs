using FluentValidation;

namespace Application.Features.RequestOperationClaims.Commands.Update;

public class UpdateRequestOperationClaimsCommandValidator : AbstractValidator<UpdateRequestOperationClaimsCommand>
{
    public UpdateRequestOperationClaimsCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequestConfigId).NotEmpty();
        RuleFor(c => c.OperationClaimId).NotEmpty();
    }
}