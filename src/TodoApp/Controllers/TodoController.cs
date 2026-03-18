using Microsoft.AspNetCore.Mvc;
using TodoApp.DTOs;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        TodoItem? item = _service.GetById(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Post(CreateTodoItemDto createTodoItemDto)
    {
        TodoItem created = _service.Create(createTodoItemDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, UpdateTodoItemDto updateTodoItemDto)
    {
        bool updated = _service.Update(id, updateTodoItemDto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        bool deleted = _service.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}