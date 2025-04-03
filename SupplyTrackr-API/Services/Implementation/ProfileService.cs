using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

public class ProfileService : IProfileService {

    private readonly IRepository<Profiles> _repository;
    private readonly IMapper _mapper;

    public ProfileService(IRepository<Profiles> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> AddProfileAsync(ProfileViewModel profileViewModel) {
        var profile = _mapper.Map<Profiles>(profileViewModel);
        return await _repository.AddAsync(profile);
    }

    public async Task<bool> DeleteProfileAsync(int id) {

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProfileViewModel>> GetAllProfilesAsync() {
        var profile = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProfileViewModel>>(profile);
    }

    public async Task<ProfileViewModel?> GetProfileByIdAsync(int id) {
        var profile = await _repository.GetByIdAsync(id);
        return profile == null ? null : _mapper.Map<ProfileViewModel>(profile);
    }

    public async Task<IEnumerable<ProfileViewModel>> GetProfilesByConditionAsync(Expression<Func<Profiles, bool>> expression) {
        var profile = await _repository.GetByConditionAsync(expression);
        return _mapper.Map<IEnumerable<ProfileViewModel>>(profile);
    }

    public async Task<bool> UpdateProfileAsync(ProfileViewModel profileViewModel) {
        var profile = await _repository.GetByIdAsync(profileViewModel.Id);
        if (profile == null) return false;

        _mapper.Map(profileViewModel, profile);
        return await _repository.UpdateAsync(profile);
    }
}
