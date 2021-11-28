using CqrsNinja.Contracts.DTO;
using FluentValidation;

namespace CqrsNinja.Core.Validators
{
    public class CreateNinjaDTOValidator : AbstractValidator<CreateNinjaDTO>
    {
        public CreateNinjaDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Bio).NotEmpty().WithMessage("Provide a brief description about the Ninja");
            RuleFor(x => x.Moniker).NotEmpty().WithMessage("Moniker is required");
            RuleFor(x => x.Clan).NotEmpty().WithMessage("Clan is required");
            RuleFor(x => x.Weapon).NotEmpty().WithMessage("Weapon is required");
        }
    }
}
