namespace knowtify.Models;

public class Update
{
    public string? Content { get; set; }
    public Worker? Author { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}