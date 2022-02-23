using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Model;
using RegistrationAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _Service;

        public AccountController(IRegisterService Service)
        {
            _Service = Service;
        }
            
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromForm]RegisterDto param)
        {

            try
            {
                /*this is custom endpoint to register user. Alternatively I can use Microsoft.AspNetCore.Identity
                 but for this sample code, i created this endpoint to register user into custome database table i.e usertb*/


                var IsUserExist = await _Service.FindUserWithEmail(param.Email);
                if (IsUserExist != null)
                {
                    return 
                        BadRequest(ResponseData.Response("Validation", errors: new { message = "Email already exist" }));

                }
                IsUserExist = await _Service.FindUserWithPhoneNumber(param.PhoneNumber);
                if (IsUserExist != null)
                {
                    return BadRequest(ResponseData.Response("Validation", errors: new { message = "Phone number already exist" }));

                }
                Usertb newuser = new Usertb()
                {
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    Email = param.Email,
                    PhoneNumber = param.PhoneNumber,
                    PassWord = param.PassWord
                };
                var register = await _Service.RegisterUser(newuser);

                var SucessStatus = register;
                if (register)
                {
                    return Ok(ResponseData.Response("Success", data: new { message = "Registration successful", SucessStatus }));

                }
                else
                {
                    return BadRequest(ResponseData.Response("Bad request", errors: new { message = "Opps ! Registration not successful.", SucessStatus }));

                }

            }
            catch (Exception ex)
            {
                var SucessStatus = false;
                return BadRequest(ResponseData.Response("Error", errors: new { message = "Something went wrong, registration fail", SucessStatus }));

            }
        }

       
        [HttpPost("UserLogin")]
        public async Task<IActionResult> LoginUser([FromForm] LoginDto param)
        {
            /*this is custom endpoint for user to login. Alternatively I can use Microsoft.AspNetCore.Identity i.e SignInManage<ApplicationUser>
                 but for this sample code, the endpoint accept password and email , validate it with user data in custom table : usertb
            */

            try
            {
                var SucessStatus = false;
                var User = await _Service.LoginUser(param);
                if (User == null)
                {
                   
                    return BadRequest(ResponseData.Response("Invalid Details", errors: new { message = "Invalid credentials", SucessStatus }));

                }
                SucessStatus = true;
                return Ok(ResponseData.Response("Success", data: new { message = "Login successful", SucessStatus, UserData= User }));

            }
            catch (Exception ex)
            {
                var SucessStatus = false;
                return BadRequest(ResponseData.Response("Error", errors: new { message = "Something went wrong, Login fail", SucessStatus }));

            }
        }
    }
}
