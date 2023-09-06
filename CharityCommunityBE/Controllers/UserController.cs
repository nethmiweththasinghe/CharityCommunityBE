using CharityCommunityBE.Data;
using CharityCommunityBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

            userDetails.Token = CreateJwt(userDetails);

            return Ok(new
            {
                Token = userDetails.Token,
                Message = "Login Success"
            });
            //return Ok(new { Message = userDetails.UserName });
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

            user.Token = CreateJwt(user);

            return Ok(new 
            { 
                Token = user.Token,
                Message = "Login Success" 
            });
        }

        [HttpGet]
        [Route("GetProjectDetails/{projectId}")]
        public async Task<IActionResult> GetProjectDetails(int projectId)
        {
            var project = await _userDbContext.Projects.FirstOrDefaultAsync(x
                => x.Id == projectId);
            if (project == null)
                return NotFound(new { Message = "Invalid!" });

            ProjectDetails projectDetails = new ProjectDetails();
            projectDetails = project;
            return Ok(projectDetails);


            //SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CharityCommunityDBCon"));
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Project WHERE Id = "+@projectId, con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //ProjectDetails projectDetails = new ProjectDetails();
            //projectDetails.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
            //projectDetails.Name = Convert.ToString(dt.Rows[0]["Name"]);
            //projectDetails.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
            //projectDetails.Description = Convert.ToString(dt.Rows[0]["Description"]);

            //return Ok(projectDetails);
        }

        [HttpPost]
        [Route("AddVolunteerDetails")]
        public async Task<IActionResult> AddVolunteerDetails(Volunteer volunteer)
        {
            if (volunteer == null)
                return BadRequest();
            volunteer.Id = Guid.NewGuid();
            _userDbContext.Volunteer.Add(volunteer);
            await _userDbContext.SaveChangesAsync();
            return Ok(new { Message = volunteer });
        }

        private string CreateJwt(UserDetails userDetails)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                //new Claim(ClaimTypes.Role,userDetails.Role),
                new Claim(ClaimTypes.Name,$"{userDetails.UserName}"),
                new Claim(ClaimTypes.GivenName,$"{userDetails.FirstName}+{userDetails.LastName}")

            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
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
