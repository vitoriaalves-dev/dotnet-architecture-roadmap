using TodoApp.Models;

namespace TodoApp.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _items = new();

    public IEnumerable<TodoItem> GetAll() => _items;

    public TodoItem? GetById(Guid id) =>
        _items.FirstOrDefault(x => x.Id == id);

    public void Add(TodoItem item) => _items.Add(item);

    public void Update(TodoItem item)
    {
        var index = _items.FindIndex(x => x.Id == item.Id);
        if (index >= 0)
            _items[index] = item;
    }

    public void Delete(Guid id)
    {
        var item = GetById(id);
        if (item != null)
            _items.Remove(item);
    }
}