using AutoMapper;
using knowtify.Contracts;
using knowtify.Models;

namespace knowtify.Mappers;

public class UpdateProfile : Profile
{
    public UpdateProfile()
    {
        CreateMap<Update, UpdateOverviewDto>();
    }
}