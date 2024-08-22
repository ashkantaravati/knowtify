namespace knowtify.Contracts;

public class WorkgroupOverviewDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<WorkgroupOverviewDto> Subgroups { get; set; }
}
