using AutoMapper;
using DataAccess.Entities;
using MonnyBE.DTOs;

namespace MonnyBE.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}