using BlogApi.Context;
using BlogApi.Dtos;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly NewsletterDb _context;
        public AuthsController(NewsletterDb context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            // users check
            var IsUserNameExsist = await _context.Users.Where(p => p.UserName == registerDto.UserName).FirstOrDefaultAsync();
            if (IsUserNameExsist != null)
            {
                return BadRequest("Bu Kullanıcı adı daha önce alınmış.");
            }
            var IsEmailExsist = await _context.Users.Where(p => p.Email == registerDto.Email).FirstOrDefaultAsync();
            if (IsEmailExsist != null)
            {
                return BadRequest("Bu mail adresi daha önce alınmış.");
            }
            // create user
            User user = new()
            {
                Email = registerDto.Email,
                NameLastName = registerDto.NameLastName,
                Password = registerDto.Password,
                UserName = registerDto.UserName
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); // save 
            ResultModel result = new()
            {
                Message = "Register user is successful!"
            };

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _context.Users.Where(p => p.UserName == loginDto.UserName && p.Password == loginDto.Password).FirstOrDefaultAsync();
            if (user == null)
                user = await _context.Users.Where(p => p.Email == loginDto.UserName).FirstOrDefaultAsync();
            if (user == null)
            {
                return BadRequest("kullanıcı ya da email adresi bulunamadı");
            }
            if (user.Password == loginDto.Password)
            {
                return Ok(user);

            }
            else
            {
                return BadRequest("sifreyi yanlış girdiniz");
            }
        }
    }
}
