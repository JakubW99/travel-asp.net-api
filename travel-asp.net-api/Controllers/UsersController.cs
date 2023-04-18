using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using travel_asp.net_api.Dto;
using travel_asp.net_api.Models;

namespace travel_asp.net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        [EnableCors("MyPolicy")]
        [HttpGet("")]
        public IQueryable<UserDto> GetUsers()
        {
            var users = _context.Users.Where(x=>x.UserName != null).Select(u => new UserDto
            {
              Id = u.Id,
              UserName = u.UserName,
              Email = u.Email
            });
            return users;
        }
        [Authorize(Roles = "Admin")]
        [EnableCors("MyPolicy")]
        // GET: api/userorders/{name}
        [HttpGet("userOrders/{name}")]
       public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders([FromRoute] string name)
        {
            return await _context.Orders.Where(x => x.Name ==name).ToListAsync();

        }
    }
}
