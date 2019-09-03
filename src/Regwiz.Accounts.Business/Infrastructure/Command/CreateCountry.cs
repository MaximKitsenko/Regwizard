using System;

namespace Regwiz.Accounts.Business.Infrastructure.Command
{
    public class CreateCountry : ICommand
    {
        public Guid CountryId { get; }
        public string Name { get; }

        public CreateCountry(Guid countryId, string name)
        {
            CountryId = countryId;
            Name = name;
        }
    }
}