#region License
// My License Info here
// 
// UserSessionController.cs
// 
#endregion

using System.Web.Mvc;
using SimpleTrack.Infrastructure;

namespace SimpleTrack.Controllers
{
    public class UserSessionController: Controller
    {
        public UserSession UserSession
        {
            get { return (UserSession) Session["UserSession"]; }
            set { Session["UserSession"] = value; }
        }
    }
}