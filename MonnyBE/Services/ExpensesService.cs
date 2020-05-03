using System;
using System.Collections.Generic;
using DataAccess.Repositories;
using DataAccess.Entities;
using AutoMapper;
using MonnyBE.DTOs;

namespace MonnyBE.Services
{
    public class ExpensesService
    {
        private readonly ExpenseRepository repository;
        private readonly IMapper _mapper;
        public ExpensesService(ExpenseRepository expenseRepository, IMapper mapper)
        {
            repository = expenseRepository;
            _mapper = mapper;
        }
        public List<ExpenseDTO> GetExpensesForThisMonth(int userId)
        {
            List<Expense> expenses = repository.GetExpensesForThismonth(userId);
            List<ExpenseDTO> expenseDTOs = _mapper.Map<List<ExpenseDTO>>(expenses);
            return expenseDTOs;
        }
        public IEnumerable<object> GetFromTo(int userId, DateTime from, DateTime to)
        {
            return repository.GetFromTo(userId, from, to);
        }
        public void Create(ExpenseDTO item)
        {
            Expense expense = _mapper.Map<Expense>(item);
            repository.Create(expense);
        }
    }
}