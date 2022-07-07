using Microsoft.AspNetCore.Mvc;
using PAS.Application.Dto.Account;

namespace PAS.Application.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        public async Task<ActionResult<AuthenticationResponse>> Signin()
        {
            return View();
        }
    }
}
