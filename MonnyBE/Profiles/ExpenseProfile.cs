using AutoMapper;
using DataAccess.Entities;
using MonnyBE.DTOs;

namespace MonnyBE.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<ExpenseDTO, Expense>();
        }
    }
}