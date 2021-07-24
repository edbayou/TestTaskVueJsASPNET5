using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskVueJsASPNET5.EntityDB;
using Microsoft.EntityFrameworkCore;
namespace TestTaskVueJsASPNET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRecordsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User model)
        {
            var exists = await _dbContext.Users.AnyAsync(f => f.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.Users.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entity = await _dbContext.Users.FindAsync(id);

                _dbContext.Users.Remove(entity);

                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                string ddd = ex.Message;
                return Ok();
            }
        }
    }
}
