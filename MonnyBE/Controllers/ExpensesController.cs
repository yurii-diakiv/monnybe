using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MonnyBE.Services;
using Microsoft.AspNetCore.Authorization;
using MonnyBE.DTOs;

namespace MonnyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesService expensesService;
        public ExpensesController(ExpensesService service)
        {
            expensesService = service;
        }

        [HttpGet("forThisMonth/{userId}"), Authorize]
        public List<ExpenseDTO> GetExpensesForThisMonth(int userId)
        {
            return expensesService.GetExpensesForThisMonth(userId);
        }

        [HttpGet("fromTo"), Authorize]
        public IEnumerable<object> GetFromTo(int userId, DateTime from, DateTime to)
        {
            return expensesService.GetFromTo(userId, from, to);
        }

        [HttpPost, Authorize]
        public void Post([FromBody] ExpenseDTO expense)
        {
            expensesService.Create(expense);
        }
    }
}
