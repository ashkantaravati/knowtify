namespace knowtify.Models;

public class Worker : IUpdateObserver
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Update> EmittedUpdates { get; set; } = [];

    public HashSet<Workgroup> Workgroups { get; private set; } = [];


    public void JoinWorkGroup(Workgroup workgroup)
    {
        //TODO: check if user is a member of the organization that this workgroup belongs to
        //TODO: Check if user is already a member
        // TODO: Check if user is allowed to become a member
        workgroup.AddMember(this);

    }

    public void EmitUpdate(Workgroup workgroup, string content)
    {
        if (Workgroups.Contains(workgroup))
        {
            var update = new Update { Content = content, Author = this };
            workgroup.AddUpdate(update);
        }
        else
        {
            Console.WriteLine("Worker is not a member of the workgroup.");
        }
    }


    public void OnUpdateReceived(Update update)
    {
        Console.WriteLine($"Notification to {Name}: New update from {update.Author.Name} in {update.Author.Workgroups}: {update.Content}");
    }
    public IEnumerable<Update> GetNewsFeed()
    {
        return Workgroups.SelectMany(wg => wg.GetAllUpdates()).OrderByDescending(u => u.Timestamp);
    }
}
