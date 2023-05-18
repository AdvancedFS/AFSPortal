using System;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = Task.FromResult(new SignInResult { Succeeded = true, Role = "1" });
            return result;
        }
    }
}

