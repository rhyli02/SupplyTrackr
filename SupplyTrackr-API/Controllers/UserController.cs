using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }
        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserViewModel userViewModel)
        {
            if (await _service.AddUserAsync(userViewModel))
            {
                return Ok(new { message = "User added successfully." });
            }
            return BadRequest(new { message = "Failed to add user." });
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserViewModel userViewModel)
        {
            if (id != userViewModel.UserId)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _service.UpdateUserAsync(userViewModel))
            {
                return Ok(new { message = "User updated successfully." });
            }
            return NotFound(new { message = "User not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _service.DeleteUserAsync(id))
            {
                return Ok(new { message = "User deleted successfully." });
            }
            return NotFound(new { message = "User not found." });
        }

        // GET: api/user/condition?status=Active
        [HttpGet("condition")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsersByCondition([FromQuery] string name)
        {
            Expression<Func<User, bool>> condition = p => p.Account == name;
            var users = await _service.GetUsersByConditionAsync(condition);
            return Ok(users);
        }
    }
}
