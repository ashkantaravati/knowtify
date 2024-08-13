namespace knowtify.Models;


public class Workgroup
{
    public string? Name { get; set; }

     public HashSet<Worker> Members { get; private set; } = new HashSet<Worker>();


    public List<Update> UpdateFeed { get; set; } = [];

    public void AddMember(Worker worker)
    {
        if (Members.Add(worker))
        {
            worker.Workgroups.Add(this);
        }
    }

    public void PublishUpdate(Update update, Worker Sender)
    {
        UpdateFeed.Add(update);
        Sender.EmittedUpdates.Add(update);
    }
}

