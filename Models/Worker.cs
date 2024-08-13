namespace knowtify.Models;

public class Worker
{
    public string? Name { get; set; }
    public List<Update> EmittedUpdates { get; set; } = [];

    public HashSet<Workgroup> Workgroups { get; private set; } = new HashSet<Workgroup>();


    public void JoinWorkGroup(Workgroup workgroup)
    {
        //TODO: Check if user is already a member
        // TODO: Check if user is allowed to become a member

        workgroup.AddMember(this);


    }
}
