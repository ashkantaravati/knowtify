namespace knowtify.Models;

public class Organization
{

    public List<Worker> Workers { get; set; } = [];

    public List<Workgroup> Workgroups { get; set; } = [];

    public static Organization MockOrganization()
    {

        var john = new Worker()
        {
            Name = "John Doe",
        };
        var jane = new Worker()
        {
            Name = "Jane Doe"
        };

        var technologyDepartment = new Workgroup()
        {
            Name = "Tech Dept."
        };

        technologyDepartment.AddMember(john);

        jane.JoinWorkGroup(technologyDepartment);

        var org = new Organization()
        {
            Workers = [john, jane],
            Workgroups = [technologyDepartment]
        };

        return org;
    }
}