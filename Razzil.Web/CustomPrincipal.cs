using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Razzil.Web
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        int IdRole { get; set; }
        string Name { get; set; }
        string Role { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        // Used by AuthorizeAttribute
        public bool IsInRole(string role)
        {
            //return Identity != null && Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role);
            return Identity != null && Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(role) && String.Equals(this.Role, role,StringComparison.CurrentCultureIgnoreCase);
        }

        public CustomPrincipal(string Name)
        {
            this.Identity = new GenericIdentity(Name);
        }

        public int Id { get; set; }
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
