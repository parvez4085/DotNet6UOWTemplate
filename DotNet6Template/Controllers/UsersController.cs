using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Template.Models;
using Template.Services;
using Template.Services.Users;

namespace DotNet6Template.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting customer details");

            var users = await _service.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserDTO model)
        {
            var users = await _service.AddUser(model);

            return Ok(users);
        }

        
    }
}
