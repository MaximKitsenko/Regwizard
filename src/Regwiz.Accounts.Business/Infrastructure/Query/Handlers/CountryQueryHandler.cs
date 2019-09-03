using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Query.Handlers
{
    public class CountryQueryHandler : IQueryHandler<FindCountriesBySearchTextQuery, Country[]>
    {
        private readonly ICountryRepository _repository;

        public CountryQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public Country[] Execute(FindCountriesBySearchTextQuery query)
        {
            var countries = _repository.ReadAll();
            if ( string.IsNullOrWhiteSpace(query.SearchText))
            {
                return countries.ToArray();
            }
            return countries.Where(user => user.Name.Contains(query.SearchText)).ToArray();
        }
    }
}