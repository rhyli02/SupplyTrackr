using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;

namespace SupplyTrackr_API.Controllers //May s ung Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _service;
        
        public ProfilesController(IProfileService service) {
            _service = service;        
        }
        // GET: api/profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileViewModel>>> GetAllProfiles() {
            var prof = await _service.GetAllProfilesAsync();
            return Ok(prof);
        
        }

        //GET: api/profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileViewModel>> GetByProfilesId(int id) {
            var prof = await _service.GetProfileByIdAsync(id);
            if (prof == null) {

                return NotFound();
            }
            return Ok(prof);
        }
        // POST: api/profile

        [HttpPost] // ung AddCategory na pinagababasihan ko may r, AddCategoryr siya
        public async Task<IActionResult> AddProfile([FromBody] ProfileViewModel profileViewModel) { 
            
            if(await _service.AddProfileAsync(profileViewModel))
            {
                return Ok(new { message = "Profile added successfully." });
            }
            return BadRequest(new { message = "Failed to add Profile." });
        
        }

        //PUT: api/profile/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, [FromBody] ProfileViewModel profileViewModel) {

            if (id != profileViewModel.Id) {

                return BadRequest("ID mismatch.");

            }
            if (await _service.UpdateProfileAsync(profileViewModel)) { return Ok(new { message = "Profile updated successfully." }); }
            return NotFound(new { message = "Profile not found." });
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id) { 
        if (await _service.DeleteProfileAsync(id))
            {
                return Ok(new { message = "Profile deleted successfully." });
            }
            return NotFound(new { message = "Profile not found." });
        
        }
    }
}
