using System;

namespace ServiceStack
{
    public class ExpensesService : Service
    {
        public object Post(Expense request)
        {
            var Session = base.SessionBag;

            var trackingData = (TrackingData)Session["Expenses"];
            if (trackingData == null)
                trackingData = new TrackingData { TotalBalance = 1000, WithdrawalsAmount = 0 };

            if (trackingData.TotalBalance >= request.Amount)
            {
                trackingData.Withdrawals += request.Amount;
                trackingData.TotalBalance -= request.Amount;
                trackingData.WithdrawalsAmount++;

                Session["Expenses"] = trackingData;

                return new ExpenseResponse
                {
                    Amount = request.Amount,
                    Total = trackingData.TotalBalance,
                    WithdrawalsAmount = trackingData.WithdrawalsAmount,
                    Status = "OK"
                };
            }
            else
            {
                return new ExpenseResponse
                {
                    Amount = request.Amount,
                    Total = trackingData.TotalBalance,
                    WithdrawalsAmount = trackingData.WithdrawalsAmount,
                    Status = "Balance too low"
                };
            }
        }
    }

    [Authenticate]
    [Route("/Expense")]
    [Route("/Expense/{Amount}")]
    public class Expense : IReturn<ExpenseResponse>
    {
        public double Amount { get; set; }
    }
    
    public class ExpenseResponse
    {
        public double Amount { get; set; }
        public double Total { get; set; }
        public String Status { get; set; }
        public int WithdrawalsAmount { get; set; }
    }

    public class TrackingData
    {
        public double Withdrawals { get; set; }
        public double TotalBalance { get; set; }
        public int WithdrawalsAmount { get; set; }
    }
}