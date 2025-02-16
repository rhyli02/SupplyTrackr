using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddUserAsync(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            return await _repository.AddAsync(user);
        }
        public async Task<bool> UpdateUserAsync(UserViewModel userViewModel)
        {
            var user = await _repository.GetByIdAsync(userViewModel.UserId);
            if (user == null) return false;

            _mapper.Map(userViewModel, user); // Update existing user entity
            return await _repository.UpdateAsync(user);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserViewModel>(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersByConditionAsync(Expression<Func<User, bool>> expression)
        {
            var user = await _repository.GetByConditionAsync(expression);
            return _mapper.Map<IEnumerable<UserViewModel>>(user);
        }

       
    }
}
