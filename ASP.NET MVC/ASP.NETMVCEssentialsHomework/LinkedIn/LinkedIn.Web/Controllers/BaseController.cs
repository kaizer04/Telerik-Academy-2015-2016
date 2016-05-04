namespace LinkedIn.Web.Controllers
{
    using LinkedIn.Data;
    using LinkedIn.Models;
    using System;
    using System.Web.Mvc;
    using System.Linq;
    using System.Web.Routing;

    public abstract class BaseController : Controller
    {
        private ILinkedInData data;
        private User userProfile;

        protected BaseController(ILinkedInData data)
        {
            this.Data = data;
        }

        protected BaseController(ILinkedInData data, User userProfile)
            :this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ILinkedInData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, System.AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}