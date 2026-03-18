namespace TodoApp.DTOs;

public class CreateTodoItemDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}