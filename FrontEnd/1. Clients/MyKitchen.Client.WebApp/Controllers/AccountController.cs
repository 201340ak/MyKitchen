using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyKitchen.DataContracts;
using MyKitchen_Client_WebApp.Configuration;

namespace MyKitchen_Client_WebApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<JWTSettings> optionsAccessor)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Options = optionsAccessor.Value;
        }

        private UserManager<IdentityUser> UserManager { get; }

        private SignInManager<IdentityUser> SignInManager { get; }

        private JWTSettings Options { get; }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials Credentials)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Credentials.Email, Email = Credentials.Email };
                var result = await UserManager.CreateAsync(user, Credentials.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return new JsonResult(  new Dictionary<string, object>
                    {
                        { "access_token", GetAccessToken(Credentials.Email) },
                        { "id_token", GetIdToken(user) }
                    });
                }
                return Errors(result);

            }
            return Error("Unexpected error");
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] Credentials Credentials)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(Credentials.Email, Credentials.Password, false, false);
                if (result.Succeeded)
                {
                var user = await UserManager.FindByEmailAsync(Credentials.Email);
                return new JsonResult(  new Dictionary<string, object>
                {
                    { "access_token", GetAccessToken(Credentials.Email) },
                    { "id_token", GetIdToken(user) }
                });
                }
                return new JsonResult("Unable to sign in") { StatusCode = 401 };
            }

            return Error("Unexpected error");
        }

        public string Test()
        {
            return "Test";
        }

        private object GetIdToken(IdentityUser user)
        {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "sub", user.Email },
                { "email", user.Email },
                { "emailConfirmed", user.EmailConfirmed },
            };
            return GetToken(payload);
        }

        private object GetAccessToken(string email)
        {
            var payload = new Dictionary<string, object>
            {
                { "sub", email },
                { "email", email }
            };
            return GetToken(payload);
        }

        private object GetToken(Dictionary<string, object> payload)
        {      
            var secret = Options.SecretKey;

            payload.Add("iss", Options.Issuer);
            payload.Add("aud", Options.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }

        private object ConvertToUnixTimestamp(DateTime now)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = now.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private IActionResult Error(string message)
        {
            return new JsonResult(message) {StatusCode = 400};
        }

        private IActionResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) {StatusCode = 400};
        }
    }
}
