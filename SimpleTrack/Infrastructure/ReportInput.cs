namespace SimpleTrack.Infrastructure
{
    public class ReportInput
    {
        public int Year { get; set; }
        public int Months { get; set; }
        public string FilterName1 { get; set; }
        public string FilterName2 { get; set; }
        public string FilterName3 { get; set; }
        public string FilterExpression1 { get; set; }
        public string FilterExpression2 { get; set; }
        public string FilterExpression3 { get; set; }
    }
}