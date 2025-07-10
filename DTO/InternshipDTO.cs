namespace InternshipApplication.DTO
{
    public class InternshipDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public DateTime? PostedAt { get; set; }
    }
}