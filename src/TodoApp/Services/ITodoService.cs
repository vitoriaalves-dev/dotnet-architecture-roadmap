using TodoApp.Models;

namespace TodoApp.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(Guid id);
    TodoItem Create(TodoItem item);
    void Update(Guid id, TodoItem item);
    void Delete(Guid id);
}