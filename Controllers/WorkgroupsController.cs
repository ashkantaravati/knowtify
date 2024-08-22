using AutoMapper;
using knowtify.Contracts;
using knowtify.Models;
using knowtify.Services;
using Microsoft.AspNetCore.Mvc;

namespace knowtify.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkgroupsController(TestOrganizationProviderService testOrganizationProviderService, IMapper mapper) : ControllerBase
{
    private readonly TestOrganizationProviderService _testOrganizationProviderService = testOrganizationProviderService;

    [HttpGet]
    public ActionResult<List<WorkgroupOverviewDto>> GetAllWorkgroups()
    {
        var org = _testOrganizationProviderService.TestOrganization;
        var workgroups = org.Workgroups.ToList();
        var result = mapper.Map<List<Workgroup>, List<WorkgroupOverviewDto>>(workgroups);

        return result;
    }

    [HttpGet("{id}")]
    public ActionResult<WorkgroupOverviewDto> GetWorkgroup(int id)
    {
        var org = _testOrganizationProviderService.TestOrganization;
        var workgroup = org.Workgroups.Find(w => w.Id == id);
        if (workgroup == null)
            return NotFound();
        var result = mapper.Map<Workgroup, WorkgroupOverviewDto>(workgroup);
        return result;
    }

    [HttpGet("{id}/updates")]
    public ActionResult<List<UpdateOverviewDto>> GetWorkgroupUpdates(int id)
    {
        var org = _testOrganizationProviderService.TestOrganization;
        var workgroup = org.Workgroups.Find(w => w.Id == id);
        if (workgroup == null)
            return NotFound("No Workgroup with this id exists");
        var result = workgroup.GetAllUpdates().ToList();
        var dto = mapper.Map<List<Update>,List<UpdateOverviewDto>>(result);
        return dto;
    }
}