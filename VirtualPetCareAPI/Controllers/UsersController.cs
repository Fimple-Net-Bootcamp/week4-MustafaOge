using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VirtualPetCare.Core;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Entities;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly PetCareDbContext _context;
        private readonly IValidator<UserCreateDto> _validator;
        private readonly IMapper _mapper;


        public UsersController(PetCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateDto>> PostUser(UserCreateDto userDto)
        {

            var user = _mapper.Map<UserCreateDto, User>(userDto);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);

        }


        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }



    }
}
