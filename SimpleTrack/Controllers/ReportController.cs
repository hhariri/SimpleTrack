using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleTrack.Infrastructure;
using SimpleTrack.Models;
using YouTrackSharp.Issues;

namespace SimpleTrack.Controllers
{
    [Authorize]
    public class ReportController : UserSessionController
    {
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult MonthlyStats(ReportInput reportInput)
        {
            // Refactor this to make it async controller 

            var issueManagement = new IssueManagement(UserSession.Connection);

            var statistics = new Cell[reportInput.Months];

            for (int i = 0; i < reportInput.Months; i++)
            {

                var month = i < 10 ? String.Format("0{0}", i + 1) : i + 1.ToString();

                var range = String.Format("{0}-{1}-01 .. {0}-{1}-{2}", reportInput.Year, month, DateTime.DaysInMonth(reportInput.Year, i + 1));
                statistics[i] = new Cell
                            {
                                FilterName1 = // project: resharper #fixed resolved date:
                                    issueManagement.GetIssueCount(
                                        string.Format("{0} {1}", reportInput.FilterExpression1, range)),
                                // project: resharper created by: resharper-developers created: 
                                FilterName2 = issueManagement.GetIssueCount(
                                    string.Format("{0} {1}", reportInput.FilterExpression2,
                                                  range)),
                                // project: resharper created by: -resharper-developers created: 
                
                                FilterName3= issueManagement.GetIssueCount(
                                    string.Format("{0} {1}", reportInput.FilterExpression3,
                                                  range)),
                            };

            }

            
            var stastics = ConvertToArray(statistics, reportInput.Months);

            var reportResult = new ReportResult()
                               {
                                   FilterName1 = reportInput.FilterName1,
                                   FilterName2 = reportInput.FilterName2,
                                   FilterName3 = reportInput.FilterName3,
                                   Statistics = stastics
                               };

            return View(reportResult);
        }

        Statistics[] ConvertToArray(Cell[] statistics, int months)
        { 
            var result = new Statistics[3];

            result[0] = new Statistics {Data = new int[months]};
            for (int i = 0; i < months; i++)
            {
                result[0].Data[i] = statistics[i].FilterName1;
            }
            result[1] = new Statistics {Data = new int[months]};
            for (int i = 0; i < months; i++)
            {
                result[1].Data[i] = statistics[i].FilterName2;
            }
            result[2] = new Statistics {Data = new int[months]};
            for (int i = 0; i < months; i++)
            {
                result[2].Data[i] = statistics[i].FilterName3;
            }
            return result;
        }
    }
}
