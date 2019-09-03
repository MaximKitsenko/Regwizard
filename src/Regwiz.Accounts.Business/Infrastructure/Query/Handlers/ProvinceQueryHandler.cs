using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Query.Handlers
{
    public class ProvinceQueryHandler :  IQueryHandler<FindProvincesByCountryQuery, Province[]>
    {
        private readonly IProvinceRepository _repository;

        public ProvinceQueryHandler(IProvinceRepository repository)
        {
            _repository = repository;
        }
        

        public Province[] Execute(FindProvincesByCountryQuery query)
        {
            //return new Province[]{new Province(1,query.Country,"zxc")};
            var countries = _repository.ReadAll();
            return countries.Where(user => user.CountryId == query.Country).ToArray();
        }
    }
}