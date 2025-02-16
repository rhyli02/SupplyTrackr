using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Interface
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(UserViewModel userViewModel);
        Task<bool> UpdateUserAsync(UserViewModel userViewModel);
        Task<bool> DeleteUserAsync(int id);
        Task<UserViewModel?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<IEnumerable<UserViewModel>> GetUsersByConditionAsync(Expression<Func<User, bool>> expression);
    }
}
