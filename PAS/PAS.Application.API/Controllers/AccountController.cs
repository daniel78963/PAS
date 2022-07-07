using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAS.Application.Dto.Account;

namespace PAS.Application.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ActionResult<AuthenticationResponse>> Signin(UserCredentials userCredentials)
        {
            var user = new IdentityUser
            {
                UserName = userCredentials.Email,
                Email = userCredentials.Email
            };
            var result = await userManager.CreateAsync(user, userCredentials.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return null; 

        }


    }
}
