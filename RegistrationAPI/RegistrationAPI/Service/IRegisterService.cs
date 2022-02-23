using RegistrationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Service
{
   public interface IRegisterService
    {
        Task<bool> RegisterUser(Usertb param);
        Task<LoginResponse> LoginUser(LoginDto param);
        Task<Usertb> FindUserWithEmail(string EmailAddress);
        Task<Usertb> FindUserWithPhoneNumber(string PhoneNumber);
    }
}
