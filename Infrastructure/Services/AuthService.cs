using Application.DTOs;
using Application.ServiceContracts;
using Application.ServiceContracts.Auth;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {

            var user = new ApplicationUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                PersonName = registerDTO.PersonName,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                // Assign default role to the user
                 await _userManager.AddToRoleAsync(user, ApplicationRole.USER);

                return true;
            }
            return false;

        }

        public async Task<AuthenticationResponse> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var tokens = await _jwtService.CreateJwtToken(user);

            user.RefreshToken = tokens.RefreshToken;
            user.RefreshTokenExpirationDateTime = tokens.RefreshTokenExpirationDateTime;
            await _userManager.UpdateAsync(user);

            return tokens;
        }

        public async Task<AuthenticationResponse> RefreshTokenAsync(TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                throw new UnauthorizedAccessException("Invalid request.");
            }

            var principal = await _jwtService.GetPrincipalFromJwtToken(tokenModel.Token);

            if (principal == null)
            {
                throw new UnauthorizedAccessException("Invalid jwt access token.");
            }

            string? email = principal.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpirationDateTime <= DateTime.Now)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }

            var authenticationResponse = await _jwtService.CreateJwtToken(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpirationDateTime = authenticationResponse.RefreshTokenExpirationDateTime;
            await _userManager.UpdateAsync(user);

            return authenticationResponse;

        }



        public Task<bool> ValidateToken(string token)
        {
            throw new NotImplementedException();
        }

     
    }
}
