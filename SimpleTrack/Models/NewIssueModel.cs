using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using YouTrackSharp.Projects;

namespace SimpleTrack.Models
{
    public class NewIssueModel
    {
        public NewIssueModel()
        {
            var projects = new List<SelectListItem>
                           {
                               new SelectListItem() {Selected = true, Text = "ReSharper", Value = "RSRP"},
                               new SelectListItem() {Selected = false, Text = "Sandbox", Value = "SB"}
                           };

            Projects = new SelectList(projects, "Value", "Text");

            var types = new List<SelectListItem>
                        {
                            new SelectListItem() {Selected = true, Text = "Bug", Value = "Bug"},
                            new SelectListItem() {Selected = true, Text = "Feature", Value = "Bug"},
                        };

            Types = new SelectList(types, "Value", "Text");
        }

        [Required]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Project { get; set; }
        [Required]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; } 
        public IEnumerable<SelectListItem> Projects { get; set; }
    }
}