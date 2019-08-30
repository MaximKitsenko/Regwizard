using System;

namespace Regwiz.Accounts.Dal.Dto
{
    public class Province : IEquatable<Province>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CountryId { get; set; }

        public bool Equals(Province other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id
                   && Id == other.Id
                   && CountryId == other.CountryId
                   && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Province)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ CountryId;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}