using System;
namespace AFSPortal.Models
{
	public class SignInResult
	{
        public bool Succeeded { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool IsLockedOut { get; set; }
        public string Role { get; set; }
    }
}

