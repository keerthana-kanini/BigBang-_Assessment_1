using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;

        public TokenController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer _userData)
        {
            if (_userData != null && _userData.Customer_Email != null && _userData.Customer_Password != null)
            {
                var user = await GetUser(_userData.Customer_Email, _userData.Customer_Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Customer_Id", user.Customer_Id.ToString()),
                         new Claim("Customer_Email", user.Customer_Email),
                        new Claim("Customer_Password",user.Customer_Password)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                     _configuration["Jwt:Audience"],
                                                     claims,
                                                     expires: DateTime.UtcNow.AddMinutes(10),
                                                     signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Customer> GetUser(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.Customer_Email == email && u.Customer_Password == password);
        }
    }
}

