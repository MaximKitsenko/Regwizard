using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Command.Handlers
{
    public class CountryCommandHandler : ICommandHandler<CreateCountry>
    {
        private readonly ICountryRepository _repository;

        public CountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateCountry message)
        {
            var item = new Country(0, message.Name);
            _repository.Create(item);
        }
    }
}