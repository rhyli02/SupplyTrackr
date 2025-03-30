
using SupplyTrackr_Profile.Models.ViewModels;
using SupplyTrackr_Profile.Models;
using System.Linq.Expressions;

namespace SupplyTrackr_Profile.Services.Interface
{
    public interface IProfileService
    {
        Task<bool> AddProfileAsync(ProfileViewModel profileViewModel);
        Task<bool> UpdateProfileAsync(ProfileViewModel profileViewModel);
        Task<bool> DeleteProfileAsync(int id);
        Task<ProfileViewModel?> GetProfileByIdAsync(int id);
        Task<IEnumerable<ProfileViewModel>> GetAllProfilesAsync();
        Task<IEnumerable<ProfileViewModel>> GetProfilesByConditionAsync(Expression<Func<Profiles, bool>> expression);
    }
}
