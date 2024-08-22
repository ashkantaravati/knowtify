namespace knowtify.Models;


public class Workgroup
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public HashSet<Worker> Members { get; private set; } = new HashSet<Worker>();


    public List<Update> Updates { get; private set; } = new List<Update>();

    public List<Workgroup> Subgroups { get; private set; } = new List<Workgroup>();

    public void AddMember(Worker worker)
    {
        if (Members.Add(worker))
        {
            worker.Workgroups.Add(this);
        }
    }

    public void AddUpdate(Update update)
    {
        Updates.Add(update);
        NotifyObservers(update);
    }

    private void NotifyObservers(Update update)
    {
        foreach (var member in GetAllMembers())
        {
            if (member != update.Author)
            {
                member.OnUpdateReceived(update);
            }
        }
    }

    public void AddSubgroup(Workgroup subgroup)
    {
        //TODO: check if subgroup is a member of this workgroup's organization
        Subgroups.Add(subgroup);
    }

    public IEnumerable<Worker> GetAllMembers()
    {
        var allMembers = new HashSet<Worker>(Members);
        foreach (var subgroup in Subgroups)
        {
            allMembers.UnionWith(subgroup.GetAllMembers());
        }
        return allMembers;
    }

    public IEnumerable<Update> GetAllUpdates()
    {
        var allUpdates = new List<Update>(Updates);
        foreach (var subgroup in Subgroups)
        {
            allUpdates.AddRange(subgroup.GetAllUpdates());
        }
        return allUpdates;
    }
}

