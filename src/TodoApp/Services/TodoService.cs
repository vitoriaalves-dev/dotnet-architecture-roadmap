using TodoApp.DTOs;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TodoItem> GetAll() => _repository.GetAll();

    public TodoItem? GetById(Guid id) => _repository.GetById(id);

    public TodoItem Create(CreateTodoItemDto createTodoItemDto)
    {
        if (string.IsNullOrWhiteSpace(createTodoItemDto.Title))
            throw new ArgumentException("Title is required");

        var item = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = createTodoItemDto.Title,
            Description = createTodoItemDto.Description
        };

        _repository.Add(item);
        return item;
    }

    public bool Update(Guid id, UpdateTodoItemDto updateTodoItemDto)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return false;

        existing.Title = updateTodoItemDto.Title;
        existing.Description = updateTodoItemDto.Description;
        existing.IsCompleted = updateTodoItemDto.IsCompleted;

        _repository.Update(existing);
        return true;
    }

    public bool Delete(Guid id)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return false;

        _repository.Delete(id);
        return true;
    }
}