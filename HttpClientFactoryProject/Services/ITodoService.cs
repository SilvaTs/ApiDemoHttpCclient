using HttpClientFactoryProject.Models;

namespace HttpClientFactoryProject.Services
{
   public interface ITodoService
   {
      Task<TodoModel> GetTodo(int id);
   }
}