using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Data;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Tasks.ToList());
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }
    }
}