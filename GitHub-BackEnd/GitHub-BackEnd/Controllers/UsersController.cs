using AutoMapper;
using GitHub_BackEnd.Data;
using GitHub_BackEnd.Dtos;
using GitHub_BackEnd.Entities;
using GitHub_BackEnd.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitHub_BackEnd.Controllers
{
    public class UsersController : BaseController
    {
        ITokenService _tokenService;
        IMapper _mapper;
        IHashingService _hashingService;
        DataContext _dataContext;

        public UsersController(ITokenService tokenService, IMapper mapper, IHashingService hashingService, DataContext dataContext)
        {
            _hashingService= hashingService;
            _tokenService= tokenService;    
            _mapper= mapper;
            _dataContext= dataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToReturnDto>> Post(RegisterDto userToCreate)
        {
            if (_dataContext.Users.Any(x => x.Username == userToCreate.Username)) return BadRequest();

            AppUser user = _mapper.Map<RegisterDto, AppUser>(userToCreate);

            _hashingService.HashPassword(userToCreate.Password, out byte[] hash, out byte[] salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return Ok(new UserToReturnDto() { Token = _tokenService.CreateToken(user), Username = userToCreate.Username});
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToReturnDto>> Login([FromBody] LoginDto loginUser)
        {
            AppUser user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == loginUser.Username);
            if (user == null)
            {
                return BadRequest();
            }

            if (_hashingService.CheckHashEquality(loginUser.Password, user.PasswordHash, user.PasswordSalt))
                return Ok(new UserToReturnDto() { Token = _tokenService.CreateToken(user), Username = user.Username});
            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserToReturnDto>> Get()
        {
            int? userId = GetIdFromToken();
            if (userId == null)
                return Unauthorized();

            
            AppUser user = await _dataContext.Users.FindAsync(userId.Value);

            if (user == null) return BadRequest();
                
            return Ok(new UserToReturnDto() { Token = _tokenService.CreateToken(user), Username = user.Username });

        }
    }
}
