
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using System.Linq.Expressions;

public interface IProfileService {
    Task<bool> AddProfileAsync(ProfileViewModel profileViewModel);
    Task<bool> UpdateProfileAsync(ProfileViewModel profileViewModel);
    Task<bool> DeleteProfileAsync(int id);
    Task<ProfileViewModel?> GetProfileByIdAsync(int id);
    Task<IEnumerable<ProfileViewModel>> GetAllProfilesAsync();
    Task<IEnumerable<ProfileViewModel>> GetProfilesByConditionAsync(Expression<Func<Profiles, bool>> expression);
}
