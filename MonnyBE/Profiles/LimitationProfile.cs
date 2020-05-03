using AutoMapper;
using DataAccess.Entities;
using MonnyBE.DTOs;

namespace MonnyBE.Profiles
{
    public class LimitationProfile : Profile
    {
        public LimitationProfile()
        {
            CreateMap<Limitation, LimitationDTO>();
            CreateMap<LimitationDTO, Limitation>();
        }
    }
}