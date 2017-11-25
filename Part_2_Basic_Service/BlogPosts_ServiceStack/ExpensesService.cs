using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStack
{
    public class ExpensesService : Service
    {
        public object Post(Expense request)
        {
            return new ExpenseResponse
            {
                Amount = request.Amount,
                Total = 500,
                Status = "OK"
            };
        }
    }

    [Route("/Expense")]
    [Route("/Expense/{Amount}")]
    public class Expense
    {
        public double Amount { get; set; }
    }
    
    public class ExpenseResponse
    {
        public double Amount { get; set; }
        public double Total { get; set; }
        public String Status { get; set; }
    }
}