using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPosts_ServiceStack
{
    public class CustomCredentialsProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            return userName == "MJurtz" && password == "password";
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
}