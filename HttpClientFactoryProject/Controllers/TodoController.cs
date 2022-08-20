using HttpClientFactoryProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
      
        [HttpGet("GetTodo/{id}")]
        public async Task<ActionResult> GetTodo(int id)
        {
            var result = await _todoService.GetTodo(id);
            return Ok(result);
        }
    }
}