using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleTrack.Models;
using YouTrackSharp.Issues;

namespace SimpleTrack.Controllers
{
    [Authorize]
    public class BoardController : UserSessionController
    {
        //
        // GET: /Board/

        public ActionResult Index()
        {
            var issueManagement = new IssueManagement(UserSession.Connection);

            var issueGroups = new IssueGroups
            {
                Backlog = issueManagement.GetIssuesBySearch("for: me #Unresolved -{In Progress}"),
                InProgress = issueManagement.GetIssuesBySearch("for: me #{In Progress}"),
                Completed = issueManagement.GetIssuesBySearch("for: me #Resolved")
            };

            return View(issueGroups);
        }
         
        public ActionResult Update(string id, string status)
        {
            var issueManagement = new IssueManagement(UserSession.Connection);

            issueManagement.ApplyCommand(id, status, "Command applied from SimpleTrack");

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
