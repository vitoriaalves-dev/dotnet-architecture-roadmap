using TodoApp.Models;
using TodoApp.DTOs;

namespace TodoApp.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(Guid id);
    TodoItem Create(CreateTodoItemDto createTodoItemDto);
    bool Update(Guid id, UpdateTodoItemDto updateTodoItemDto);
    bool Delete(Guid id);
}