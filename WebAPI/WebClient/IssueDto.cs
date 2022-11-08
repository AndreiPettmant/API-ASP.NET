using System.ComponentModel.DataAnnotations;
namespace WebClient
{
    internal class IssueDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority GetPriority { get; set; }
        public IssueType GetIssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low, Mediu, High
    }

    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
