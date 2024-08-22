using knowtify.Models;

namespace knowtify.Services;

public class TestOrganizationProviderService
{
    //TODO: replace this class with actual tests
    public Organization TestOrganization { get; set; } = MockOrganization();

    public static Organization MockOrganization()
    {
        Worker worker1 = new Worker { Id = 1, Name = "John Doe" };
        Worker worker2 = new Worker { Id = 2, Name = "Jane Smith" };
        Workgroup devGroup = new Workgroup { Id = 1, Name = "Development" };
        Workgroup subDevGroup = new Workgroup { Id = 2, Name = "Frontend Development" };
        Organization org = new Organization { Name = "Tech Corp" };

        org.AddWorkgroup(devGroup);
        org.AddWorkgroup(subDevGroup);
        org.AddMember(worker1);
        org.AddMember(worker2);

        devGroup.AddSubgroup(subDevGroup);



        worker1.JoinWorkGroup(devGroup);
        worker2.JoinWorkGroup(subDevGroup);

        worker1.EmitUpdate(devGroup, "We have a new project starting next week.");
        worker2.EmitUpdate(subDevGroup, "Frontend team meeting tomorrow.");

        foreach (var update in worker1.GetNewsFeed())
        {
            Console.WriteLine($"{update.Timestamp}: {update.Author.Name} - {update.Content}");
        }

        return org;
    }

}
