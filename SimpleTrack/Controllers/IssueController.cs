using System.Web.Mvc;
using SimpleTrack.Infrastructure;
using SimpleTrack.Models;
using YouTrackSharp.Infrastructure;
using YouTrackSharp.Issues;
using YouTrackSharp.Projects;

namespace SimpleTrack.Controllers
{
    [Authorize]
    public class IssueController : UserSessionController
    {
        public ActionResult New()
        {
            return View(new NewIssueModel());
        }

        [HttpPost]
        public ActionResult New(NewIssueModel model)
        {
            if (ModelState.IsValid)
            {

                var issueManagement = new IssueManagement(UserSession.Connection);
                
                var issue = new Issue() 
                              {
                                  Description = model.Description,
                                  ProjectShortName = model.Project,
                                  Summary = model.Summary,
                                  Type = model.Type,
                                  ReporterName = UserSession.Username
                                  
                              };
                issueManagement.CreateIssue(issue);

                return RedirectToAction("Index", "Home");
            }
            return View(model);

        }
    }
}
