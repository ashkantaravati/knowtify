namespace knowtify.Contracts;

public class UpdateOverviewDto
{
    public string? Content { get; set; }
    public UpdateAuthorOverviewDto Author { get; set; }
    public DateTime Timestamp { get; set; }
}