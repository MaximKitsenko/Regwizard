using System;

namespace Regwiz.Accounts.Business.Infrastructure.Command
{
    public class CreateProvince : ICommand
    {
        public Guid ProvinceId { get; }
        public string Name { get; }
        public int CountryId { get; }

        public CreateProvince(Guid provinceId, int countryId, string name)
        {
            ProvinceId = provinceId;
            CountryId = countryId;
            Name = name;
        }
    }
}