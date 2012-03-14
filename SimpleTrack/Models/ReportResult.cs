using SimpleTrack.Infrastructure;

namespace SimpleTrack.Models
{
    public class ReportResult
    {
        public string FilterName1 { get; set; }
        public string FilterName2 { get; set; }
        public string FilterName3 { get; set; }
        public Statistics[] Statistics { get; set; }
    }
}