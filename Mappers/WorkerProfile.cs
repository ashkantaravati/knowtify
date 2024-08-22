using AutoMapper;
using knowtify.Contracts;
using knowtify.Models;

namespace knowtify.Mappers;

public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<Worker, UpdateAuthorOverviewDto>();
    }
}