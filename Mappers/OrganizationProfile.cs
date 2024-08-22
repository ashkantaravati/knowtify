using AutoMapper;
using knowtify.Contracts;
using knowtify.Models;

namespace knowtify.Mappers;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Workgroup, WorkgroupOverviewDto>();
    }
}