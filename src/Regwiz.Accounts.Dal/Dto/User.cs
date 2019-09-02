using System;

namespace Regwiz.Accounts.Dal.Dto
{
    public partial class User : IEquatable<User>
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int ProvinceId { get; set; }

        public User(int id, string mail, string password, int provinceId)
        {
            Id = id;
            Mail = mail;
            Password = password;
            ProvinceId = provinceId;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Mail, other.Mail) && string.Equals(Password, other.Password) && ProvinceId == other.ProvinceId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Mail != null ? Mail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProvinceId;
                return hashCode;
            }
        }
    }
}