﻿using Api.DTO;
using Api.Extensions;
using Api.V1.Controllers;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Api.V1
{

    [ApiVersion("1.0")]
    [Route("Security/v{version:ApiVersion}")]
    [ApiController]
    public class SecurityController : MainController
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly AppSetingsJWT _appSettings;
        private readonly ICustomerService _CustomerService;
        private readonly IMapper _mapper;

        public SecurityController(SignInManager<IdentityUser> SignInManager,
                                                UserManager<IdentityUser> UserManager,
                                                IOptions<AppSetingsJWT> appSettings,
                                                ICustomerService CustomerService,
                                                IMapper mapper)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _appSettings = appSettings.Value;
            _CustomerService = CustomerService;
            _mapper = mapper;

        }


        [HttpPost("Register-NewUser")]
        public async Task<ActionResult<DtoRegister>> RegisterUser([FromBody] DtoCustomer NewUserModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                Email = NewUserModel.Email,
                UserName = NewUserModel.Email,
                EmailConfirmed = true
            };
            var result = await _UserManager.CreateAsync(user, NewUserModel.Password);

            if (result.Succeeded)
            {
                await _CustomerService.PostCustomer(_mapper.Map<Customer>(NewUserModel));
              

                return Ok();
            }
            else
            {
                foreach (var e in result.Errors)
                {
                    NewUserModel.StatusRegistro = NewUserModel.StatusRegistro + "\n" + e.Description.ToString();
                    return BadRequest(NewUserModel);
                }
            }

            return Ok();

        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] DtoLogin UserLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _SignInManager.PasswordSignInAsync(UserLogin.Email, UserLogin.Password, false, true);

            if (result.Succeeded)
            {

                DtoCustomer AccountValues = await GetUserByEmail(UserLogin.Email);

                AccountValues.StatusRegistro = "user logged successful!";
               // UserLogin.TokenJWT = await GerarJwt(UserLogin.Email);
                AccountValues.TokenJWT = await GerarJwt(UserLogin.Email);

                return Ok(AccountValues);
            }
            else
            {
                UserLogin.StatusRegistro = "Error! Verify user os password!";
                return BadRequest(UserLogin);
            }

            return Ok();
        }
        private async Task<DtoCustomer> GetUserByEmail(string Email)
        {           
                var usuario = _mapper.Map<DtoCustomer>( await _CustomerService.GetByEmailCustomer(Email));               
                return usuario;  
            
        }

        private async Task<string> GerarJwt(string email)
        {

            //para uso de claims
            var user = await _UserManager.FindByEmailAsync(email);
            var claims = await _UserManager.GetClaimsAsync(user);
            var userRoles = await _UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            //para uso de claims


            var tokenHandler = new JwtSecurityTokenHandler();
            //injetar a classe appSetings no construtor com IOptions<AppSettings>;

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {

                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;

        }
        //para uso de claims
        private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);


    }
}
