using AutoMapper;
using Project.MovieStore.Application.Results;
using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;
using Project.MovieStore.Application.Services.Users.Dto;
using BC = BCrypt.Net.BCrypt;


namespace Project.MovieStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResult<List<UserGetDto>>> GetAllAsync()
        {
            var result = new ServiceResult<List<UserGetDto>>();

            return result.Build(await _UserRepository.GetAllAsync());
        }

        public async Task<ServiceResult<UserGetDto>> GetAsync(int id)
        {
            var result = new ServiceResult<UserGetDto>();

            return result.Build(await _UserRepository.GetByIdAsync(id));
        }

        public async Task<ServiceResult<UserGetDto>> AddAsync(UserAddDto data)
        {
            var result = new ServiceResult<UserGetDto>();
            var record = _mapper.Map<User>(data);

            if (await CheckNameOrMailAlreadyAsync(data.UserName, data.Email))
            {
                result.Fail("There is a registered user with a username or e-mail address. Please try again with different information.");
                return result;
            };

            record.Password = CreatePassword(data.Password);

            await _UserRepository.AddAsync(record);
            await _UserRepository.SaveAsync();

            return await GetAsync(record.Id);
        }

        public async Task<ServiceResult<UserGetDto>> UpdateAsync(int id, UserUpdateDto data)
        {
            var result = new ServiceResult<UserGetDto>();
            var record = await _UserRepository.GetByIdAsync(id);

            if (await CheckNameOrMailAlreadyAsync(data.UserName, data.Email))
            {
                result.Fail("There is a registered user with a username or e-mail address. Please try again with different information.");
                return result;
            };

            record.Name = data.Name;
            record.LastName = data.LastName;
            record.Email = data.Email;
            record.UserName = data.UserName;

            await _UserRepository.UpdateAsync(record);
            await _UserRepository.SaveAsync();

            return await GetAsync(id);
        }


        public async Task<BaseServiceResult> PatchPasswordAsync(int id, UserPatchPasswordDto data)
        {
            var result = new BaseServiceResult();
            var record = await _UserRepository.GetByIdAsync(id);

            if (ValidPassword(data.OldPassword, record.Password))
            {
                result.Fail("Old password is incorrect");
                return result;
            };

            record.Password = CreatePassword(data.NewPassword);

            await _UserRepository.UpdateAsync(record);
            await _UserRepository.SaveAsync();

            return result;
        }

        public async Task<User> GetUserByMailOrUserName(string userNameOrEmail)
        {
            return await _UserRepository.GetAsync(predicate: x => x.Email.Equals(userNameOrEmail) || x.UserName.Equals(userNameOrEmail));
        }

        private async Task<bool> CheckNameOrMailAlreadyAsync(string userName, string email)
        {
            return await _UserRepository.AnyAsync(x => x.UserName.ToLower().Equals(userName.ToLower()) || x.Email.ToLower().Equals(email.ToLower()));
        }


        public bool ValidPassword(string password, string hashPassword)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            return !BC.Verify(password, hashPassword);
        }

        private string CreatePassword(string password)
        {
            return BC.HashPassword(password);
        }

        public async Task<BaseServiceResult> DeleteAsync(int id)
        {
            var result = new BaseServiceResult();

            await _UserRepository.DeleteAsync(id);
            result.CheckSuccess(await _UserRepository.SaveAsync());

            return result;
        }

    }
}