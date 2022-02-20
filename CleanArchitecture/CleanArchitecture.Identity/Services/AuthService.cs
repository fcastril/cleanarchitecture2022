using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, 
                           SignInManager<ApplicationUser> signInManager, 
                           JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"El Usuario con Email {request.Email} no existe");
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new Exception($"Las credenciales son incorrectas");
            }

            AuthResponse authResponse = new AuthResponse()
            {
                Id = new Guid(user.Id),
                Email = user.Email,
                Token = "",
                Username = user.UserName,
            };
            return authResponse;

        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser != null)
            {
                throw new Exception($"El Username ya se encuentra registrado");
            }

            ApplicationUser existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                throw new Exception($"El Email ya se encuentra registrado");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                Name = request.Name,
                UserName = request.Username,
                EmailConfirmed = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Invitado");
                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = "",
                    UserId = new Guid(user.Id),
                    Username = user.UserName
                };
            }

            throw new Exception($"{result.Errors}");
        }
    }
}
