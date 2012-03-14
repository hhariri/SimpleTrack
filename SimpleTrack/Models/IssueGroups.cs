using System.Collections.Generic;
using YouTrackSharp.Issues;

namespace SimpleTrack.Models
{
    public class IssueGroups
    {
        public IEnumerable<Issue> Backlog { get; set; }
        public IEnumerable<Issue> InProgress { get; set; }
        public IEnumerable<Issue> Completed { get; set; }
    }
}