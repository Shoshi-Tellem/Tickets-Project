using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.Core.DTOs;
using server.Core.Entities;
using server.Core.Services;
using server.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            IEnumerable<User> users = await _userService.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User? user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null.");
            User addedUser = await _userService.AddUserAsync(new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password
            });
            return CreatedAtAction(nameof(Get), new
            {
                id = addedUser.UserId
            }, addedUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null.");
            User? updatedUser = await _userService.UpdateUserAsync(id, new User { FullName = user.FullName, Email = user.Email });
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User? deletedUser = await _userService.DeleteUserAsync(id);
            if (deletedUser == null)
                return NotFound();
            return Ok(deletedUser);
        }
    }
}
