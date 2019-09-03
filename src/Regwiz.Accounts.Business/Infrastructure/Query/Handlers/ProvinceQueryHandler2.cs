using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Query.Handlers
{
    public class ProvinceQueryHandler2 : IQueryHandler<FindProvincesBySearchTextQuery, Province[]>
    {
        private readonly IProvinceRepository _repository;

        public ProvinceQueryHandler2(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public Province[] Execute(FindProvincesBySearchTextQuery query)
        {
            var provinces = _repository.ReadAll();
            if (string.IsNullOrWhiteSpace(query.SearchText))
            {
                return provinces.ToArray();
            }
            return provinces.Where(province => province.Name.Contains(query.SearchText)).ToArray();
        }
        
    }
}