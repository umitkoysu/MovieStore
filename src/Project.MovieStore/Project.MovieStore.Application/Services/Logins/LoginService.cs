using AutoMapper;
using Project.MovieStore.Application.Authentication;
using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services;
using Project.MovieStore.Application.Services.Categories.Dto;
using Project.MovieStore.Application.Services.Logins.Dto;
using Project.MovieStore.Application.Services.Users.Dto;
using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;

namespace Project.MovieStore.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly JwtTokenBuilder _jwtTokenBuilder;

        public LoginService(IMapper mapper, JwtTokenBuilder jwtTokenBuilder, IUserService userService)
        {
            _mapper = mapper;
            _jwtTokenBuilder = jwtTokenBuilder;
            _userService = userService;
        }


        public async Task<ServiceResult<LoginGetDto>> LoginManagerAsync(LoginPostDto login)
        {
            var result = new ServiceResult<LoginGetDto>();

            var user = await _userService.GetUserByMailOrUserName(login.UserNameOrEEmail);

            if (user is null)
            {
                result.Fail("Email or Username is incorrect");
                return result;
            }

            if (_userService.ValidPassword(login.Password, user.Password))
            {
                result.Fail("Password is incorrect");
                return result;
            }

            result.Data = new LoginGetDto
            {
                User = _mapper.Map<UserGetSummaryDto>(user),
                Tokens = _jwtTokenBuilder.GetToken(user.Id)
            };

            return result;
        }


        public async Task<ServiceResult<RefreshLoginGetDto>> RefReshLoginManagerAsync(int userId)
        {
            var result = new ServiceResult<RefreshLoginGetDto>();

            var tokens = _jwtTokenBuilder.GetToken(userId);

            result.Data = new RefreshLoginGetDto
            {
                RefreshToken = tokens.RefreshToken,
                Token = tokens.Token,
            };

            return result;
        }


    }
}