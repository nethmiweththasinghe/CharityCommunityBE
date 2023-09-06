using CharityCommunityBE.Data;
using CharityCommunityBE.Models;
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
    public class AdminController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly UserDbContext _userDbContext;
        public AdminController(IConfiguration configuration, UserDbContext userDbContext)
        {
            _configuration = configuration;
            _userDbContext = userDbContext;
        }

        //[HttpPost]
        //[Route("AddAdminDetails")]
        //public async Task<IActionResult> AddAdminDetails(AdminDetails adminDetails)
        //{
        //    if (adminDetails == null)
        //        return BadRequest();
        //    adminDetails.Id = Guid.NewGuid();
        //    _userDbContext.Admin.Add(adminDetails);
        //    await _userDbContext.SaveChangesAsync();
        //    return Ok(new { Message = adminDetails.UserName });
        //}

        //[HttpPost("AuthenticateAdmin")]
        //public async Task<IActionResult> AuthenticateAdmin([FromBody] AdminDetails adminDetails)
        //{
        //    if (adminDetails == null)
        //        return BadRequest();

        //    var user = await _userDbContext.Admin.FirstOrDefaultAsync(x
        //        => x.UserName == adminDetails.UserName && x.Password == adminDetails.Password);

        //    if (user == null)
        //        return NotFound(new { Message = "User Not Found!" });

        //    user.Token = CreateJwt(user);

        //    return Ok(new
        //    {
        //        Token = user.Token,
        //        Message = "Login Success"
        //    });
        //}

        //private string CreateJwt(AdminDetails adminDetails)
        //{
        //    var jwtTokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("veryverysceret.....");
        //    var identity = new ClaimsIdentity(new Claim[]
        //    {
        //        //new Claim(ClaimTypes.Role,userDetails.Role),
        //        new Claim(ClaimTypes.Name,$"{adminDetails.UserName}"),
        //        new Claim(ClaimTypes.GivenName,$"{adminDetails.FirstName}+{adminDetails.LastName}")

        //    });

        //    var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = identity,
        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = credentials
        //    };
        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        //    return jwtTokenHandler.WriteToken(token);
        //}

        [HttpPost]
        [Route("AddProjectDetails")]
        public async Task<IActionResult> AddProjectDetails(ProjectDetails projectDetails)
        {
            if (projectDetails == null)
                return BadRequest();
            //projectDetails.Id = Guid.NewGuid();
            projectDetails.CreatedDate = DateTime.Now;
            _userDbContext.Projects.Add(projectDetails);
            await _userDbContext.SaveChangesAsync();
            return Ok(new { Message = "Succesfully added." });
        }

        //[HttpGet]
        //[Route("GetProjectDetails/{projectId}")]
        //public async Task<IActionResult> GetProjectDetails(int projectId)
        //{

        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CharityCommunityDBCon"));
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Project", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    for (int i = 0; i > 10; i++)
        //    {
        //        ProjectDetails projectDetails = new ProjectDetails();
        //        projectDetails.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
        //        projectDetails.Name = Convert.ToString(dt.Rows[0]["Name"]);
        //        projectDetails.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
        //        projectDetails.Description = Convert.ToString(dt.Rows[0]["Description"]);
        //    }

        //    return Ok(projectDetails);
        //}
    }
}
