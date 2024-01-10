using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Property.API.Data;
using Property.API.Dtos.User;
using Property.API.Entities;
using Property.API.Services.Interfaces;

namespace Property.API.Services.NewFolder
{
    public class UserService : IUserService
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public UserService(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PropertyUser?> GetAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<PropertyUser> AddAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<PropertyUser>(createUserDto);
            await _context.Users.AddAsync(user);
            return user;
        }
    }
}
