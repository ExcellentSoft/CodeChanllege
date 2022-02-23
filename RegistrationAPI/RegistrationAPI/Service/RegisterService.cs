using RegistrationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Service
{
    public class RegisterService : IRegisterService

    {
        private RegisterContext _regContext;
        public RegisterService(RegisterContext registerContext)
        {
            _regContext = registerContext;
        }

        public Task<Usertb> FindUserWithEmail(string EmailAddress)
        {
            var response = (from user in _regContext.Usertbs where user.Email.ToLower() == EmailAddress.ToLower() select user).FirstOrDefault();
            return Task.FromResult(response);
        }

        public Task<Usertb> FindUserWithPhoneNumber(string PhoneNumber)
        {
            var response = (from user in _regContext.Usertbs where user.PhoneNumber == PhoneNumber select user).FirstOrDefault();
            return Task.FromResult(response);
        }

         

        public Task<LoginResponse> LoginUser(LoginDto param)
        {
            
            var response = (from user in _regContext.Usertbs
                            where user.Email.ToLower() == param.Email.ToLower() && user.PassWord==param.PassWord

                            select new LoginResponse
                            {
                                FirstName=user.FirstName,
                                LastName=user.LastName,Email=user.Email,PhoneNumber=user.PhoneNumber }).FirstOrDefault();

            return Task.FromResult(response);
        }

        public async Task<bool> RegisterUser(Usertb param) 
        { 
            try
            {
                _regContext.Add(param);
                await _regContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
