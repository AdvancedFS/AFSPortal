using System;
using AFSPortal.Models;

namespace AFSPortal.Repository
{
	public interface IAccountRepository
	{
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
    }
}

