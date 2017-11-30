using ServiceStack;
using ServiceStack.Auth;
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
                Plugins.Add(new AuthFeature(() =>
                new AuthUserSession(), new IAuthProvider[] {
                    new BasicAuthProvider() }));

                var userRepository = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepository);

                string hash;
                string salt;

                new SaltedHash().GetHashAndSaltString("password", out hash, out salt);
                userRepository.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    DisplayName = "Marcel Jurtz",
                    Email = "jurtz@example.com",
                    UserName = "MJurtz",
                    FirstName = "Marcel",
                    LastName = "Jurtz",
                    //Roles = new List<string> { RoleNames.Admin },
                    //Permissions = new List<string> { "GetStatus"},
                    PasswordHash = hash,
                    Salt = salt
                }, "password");
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