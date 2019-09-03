using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Query.Handlers
{
    public class ProvinceQueryHandler : IQueryHandler<FindProvincesBySearchTextQuery, Province[]>
    {
        private readonly IProvinceRepository _repository;

        public ProvinceQueryHandler(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public Province[] Execute(FindProvincesBySearchTextQuery query)
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