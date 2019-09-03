using System;

namespace Regwiz.Accounts.Dal.Dto
{
    public partial class Country: IEquatable<Country>
    {
        public Country(int id, string name)
        {
            this.Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Country other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id 
                   && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Country) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}