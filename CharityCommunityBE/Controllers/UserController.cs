using CharityCommunityBE.Data;
using CharityCommunityBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace CharityCommunityBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly UserDbContext _userDbContext;
        public UserController(IConfiguration configuration, UserDbContext userDbContext)
        {
            _configuration = configuration;
            _userDbContext = userDbContext;
        }

        [HttpGet]
        [Route("GetUserDetails/{userName}")]
        public async Task<IActionResult> GetUserDetails(string userName)
       {
            var user = await _userDbContext.Users.FirstOrDefaultAsync(x
                => x.UserName == userName);
            if (user == null)
                return NotFound(new { Message = "User Not Found!" });

            UserDetails userDetails = new UserDetails();
            userDetails = user;
            return Ok(userDetails);
        }

        [HttpPost]
        [Route("AddUserDetails")]
        public async Task<IActionResult> AddUserDetails(UserDetails userDetails)
        {
            if (userDetails == null)
                return BadRequest();
            userDetails.Id = Guid.NewGuid();
            _userDbContext.Users.Add(userDetails);
            await _userDbContext.SaveChangesAsync();
            return Ok(new { Message = userDetails.UserName });
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDetails userDetails)
        {
            if (userDetails == null)
                return BadRequest();

            var user = await _userDbContext.Users.FirstOrDefaultAsync(x 
                => x.UserName == userDetails.UserName && x.Password == userDetails.Password);
            if (user == null)
                return NotFound(new { Message = "User Not Found!" });

            return Ok(new { Message = userDetails.UserName });
        }



        //[HttpPost("UpdateUserDetails")]
        //public async Task<IActionResult> UpdateUserDetails(UserDetails userDetails)
        //{
        //    if (userDetails == null)
        //        return BadRequest();

        //    var user = await _userDbContext.Users.FirstOrDefaultAsync(x
        //        => x.UserName == userDetails.UserName);
        //    _userDbContext.Users.Update(userDetails);
        //    await _userDbContext.SaveChangesAsync();
        //    if (user == null)
        //        return NotFound(new { Message = "User Not Found!" });

        //    return Ok(new { Message = userDetails.UserName });
        //}          
    }
}
