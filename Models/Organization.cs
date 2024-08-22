namespace knowtify.Models;

public class Organization
{

    public string? Name { get; set; }
    public List<Worker> Members { get; set; } = [];

    public List<Workgroup> Workgroups { get; set; } = [];

    public void AddWorkgroup(Workgroup workgroup)
    {
        Workgroups.Add(workgroup);
    }

    public void AddMember(Worker member)
    {
        Members.Add(member);
    }

    public IEnumerable<Update> GetAllUpdates()
    {
        return Workgroups.SelectMany(wg => wg.Updates).OrderByDescending(u => u.Timestamp);
    }

}