using AngularAPI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public JobsController(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }
       
        [Authorize]
        [HttpGet("Jobs")]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetAllJobs()
        {
            // Retrieve all jobs and return as ActionResult
            var jobs = await _Context.job.ToListAsync();
            return Ok(jobs);
        }
       
        [HttpPost("addjobsdata")]
        public async Task<IActionResult> AddJobsdata([FromBody] Jobs jobsObj)
        {
            if (jobsObj == null)
                return BadRequest();

            await _Context.job.AddAsync(jobsObj);
            await _Context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Job Added Successfully!"
            });
        }

    }
}
