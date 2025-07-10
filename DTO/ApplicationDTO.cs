namespace InternshipApplication.DTO
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string ResumePath { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string InternshipTitle { get; set; }
        public string UserName { get; set; }
    }
}
