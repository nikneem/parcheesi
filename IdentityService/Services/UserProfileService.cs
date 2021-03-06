﻿using System;
using System.Linq;
using System.Threading.Tasks;
using HexMaster.Parcheesi.IdentityService.Contracts.Repositories;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace HexMaster.Parcheesi.IdentityService.Services
{
    public class UserProfileService : IProfileService
    {


        private readonly IUsersRepository _userRepository;

        public UserProfileService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                {
                    //get user from db (in my case this is by email)
                    var user = await _userRepository.Find(context.Subject.Identity.Name, "");

                    if (user != null)
                    {
                        var claims = PasswordValidationService.GetUserClaims(user);

                        //set issued claims to return
                        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
                else
                {
                    //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                    //where and subject was set to my user id.
                    var userIdClaim = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);

                    if (Guid.TryParse(userIdClaim?.Value, out Guid userId))
                    {
                        //get user from db (find user by user id)
                        var user = await _userRepository.Find(userId);

                        // issue the claims for the user
                        if (user != null)
                        {
                            var claims = PasswordValidationService.GetUserClaims(user);

                            context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                var userIdClaim = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);

                if (Guid.TryParse(userIdClaim?.Value, out Guid userId))
                {
                    //get user from db (find user by user id)
                    var user = await _userRepository.Find(userId);

                    // issue the claims for the user
                    if (user != null)
                    {
                        context.IsActive = user.IsVerified;
                    }
                }
            }
            catch (Exception ex)
            {
                //handle error logging
            }
        }
    }
}
