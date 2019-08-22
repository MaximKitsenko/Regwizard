using System.Collections.Generic;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IUserInfoRepository
    {
        IEnumerable<EntityEntry<Message>> CreateMessages(params Message[] messages);
        List<Message> ReadMessages(int userId);
        void UpdateMessages(params Message[] messages);
        void DeleteMessages(params Message[] messageIds);
    }
}