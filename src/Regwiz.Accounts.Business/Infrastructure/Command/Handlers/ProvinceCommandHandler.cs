using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Command.Handlers
{
    public class ProvinceCommandHandler : ICommandHandler<CreateProvince>
    {
        private readonly IProvinceRepository _repository;

        public ProvinceCommandHandler(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateProvince message)
        {
            var item = new Province(0, message.CountryId, message.Name);
            _repository.Create(item);
        }
    }
}