using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
    public class CreateAccountModel
    {
        public Guid Identifier { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public async Task<Account> Create(DatabaseContext databaseContext)
        {
            var invite = await databaseContext
                .Invites
                .Include(x => x.Organization)
                .SingleAsync(x => x.Identifier == Identifier && x.AccountId == null);

            var account = new Account
            {
                Email = invite.Email,
                Role = invite.Role,
                Invite = invite,
                Organization = invite.Organization,
                Password = Password,
                CreatedAt = DateTime.UtcNow,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName
            };

            await databaseContext.Accounts.AddAsync(account);

            return account;
        }
    }
}