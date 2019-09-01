using System;

namespace Regwiz.Accounts.Business.Infrastructure.Command
{
    public class CreateUser : ICommand
    {
        public Guid InventoryItemId { get; }
        public string Name { get; }
        public string Password { get; }
        public string Mail { get; }

        public CreateUser(Guid inventoryItemId, string name, string password, string mail)
        {
            InventoryItemId = inventoryItemId;
            Name = name;
            Password = password;
            Mail = mail;
        }
    }
}