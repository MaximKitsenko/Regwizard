namespace Regwiz.Accounts.Dal.Dto
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public bool Equals(UserAccount other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id
                   && Id == other.Id
                   && string.Equals(Mail, other.Mail);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserAccount)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ (Mail != null ? Mail.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Password.GetHashCode();
                return hashCode;
            }
        }
    }
}