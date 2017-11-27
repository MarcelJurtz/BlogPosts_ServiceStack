using ServiceStack;
using System;

namespace BlogPosts_ServiceStack
{
    public class Global : System.Web.HttpApplication
    {
        public class ExpenseTrackerAppHost : AppHostBase
        {
            public ExpenseTrackerAppHost() : base("Expense Tracker", typeof(ExpensesService).Assembly) { }
            public override void Configure(Funq.Container container)
            {

            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new ExpenseTrackerAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}