using Razzil.DataAccess.Repository;
using Razzil.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Razzil.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    CustomPrincipalSerializeModel serializeModel = Serializer.JavaScriptDeserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.Id = serializeModel.Id;
                    newUser.IdRole = serializeModel.RoleId;
                    newUser.Name = serializeModel.Name;
                    newUser.Role = new Entities().UserRoles.SingleOrDefault(r => r.Id == newUser.IdRole).Name;
                    HttpContext.Current.User = newUser;
                    //HttpContext.Current.User = Thread.CurrentPrincipal = new GenericPrincipal(newUser.Identity, roles.Split(';'));
                    //var id = User;
                }
                catch (Exception)
                {
                    //somehting went wrong
                }
            }
        }
    }
}
