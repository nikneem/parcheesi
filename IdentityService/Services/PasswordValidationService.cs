using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HexMaster.Parcheesi.IdentityService.Contracts.Repositories;
using HexMaster.Parcheesi.IdentityService.DomainModels;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace HexMaster.Parcheesi.IdentityService.Services
{
    public class PasswordValidationService : IResourceOwnerPasswordValidator
    {
        //repository to get user from db
        private readonly IUsersRepository _userRepository;

        public PasswordValidationService(IUsersRepository userRepository)
        {
            _userRepository = userRepository; //DI
        }

        //this is used to validate your user account with provided grant at /connect/token
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                //get your user model from db (by username - in my case its email)
                var user = await _userRepository.Find(context.UserName, context.Password);
                if (user != null)
                {
                    context.Result = new GrantValidationResult(
                        subject: user.Id.ToString(),
                        authenticationMethod: "custom",
                        claims: GetUserClaims(user));

                    return;
                }

                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,
                    "Username & Password combination incorrect");
            }
            catch (Exception)
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
        }

        //build claims array from user data
        public static Claim[] GetUserClaims(User user)
        {
            return new[]
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString() ?? ""),
                new Claim(JwtClaimTypes.Name, user.DisplayName),
                new Claim(JwtClaimTypes.Email, user.Email),
//            new Claim("some_claim_you_want_to_see", user.Some_Data_From_User ?? ""),

                //roles
//            new Claim(JwtClaimTypes.Role, user.Role)
            };
        }
    }
}
