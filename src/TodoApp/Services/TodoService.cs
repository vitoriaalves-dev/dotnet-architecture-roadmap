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

    public TodoItem Create(TodoItem item)
    {
        item.Id = Guid.NewGuid();
        _repository.Add(item);
        return item;
    }

    public void Update(Guid id, TodoItem item)
    {
        item.Id = id;
        _repository.Update(item);
    }

    public void Delete(Guid id) => _repository.Delete(id);
}