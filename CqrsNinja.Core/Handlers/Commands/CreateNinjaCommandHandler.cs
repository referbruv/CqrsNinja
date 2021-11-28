using MediatR;
using CqrsNinja.Contracts.Data;
using CqrsNinja.Contracts.DTO;
using CqrsNinja.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using CqrsNinja.Core.Exceptions;

namespace CqrsNinja.Providers.Handlers.Commands
{
    public class CreateNinjaCommand : IRequest<int>
    {
        public CreateNinjaDTO Model { get; }
        public CreateNinjaCommand(CreateNinjaDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateNinjaCommandHandler : IRequestHandler<CreateNinjaCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateNinjaDTO> _validator;

        public CreateNinjaCommandHandler(IUnitOfWork repository, IValidator<CreateNinjaDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateNinjaCommand request, CancellationToken cancellationToken)
        {
            CreateNinjaDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Ninja
            {
                Name = model.Name,
                Moniker = model.Moniker,
                Bio = model.Bio,
                Clan = model.Clan,
                Weapon = model.Weapon
            };

            _repository.Ninjas.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}