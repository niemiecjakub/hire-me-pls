using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents a job posting or vacancy, including the role's title, company, responsibilities, and requirements.")]
  public class JobDocument
  {
    [Description("The title of the job position (e.g., 'Software Engineer', 'Marketing Manager').")]
    public string Title { get; set; }

    [Description("A brief summary or overview of the job, highlighting its purpose and key objectives.")]
    public string Summary { get; set; }

    [Description("The name of the company or organization offering the job.")]
    public string Company { get; set; }

    [Description("The geographic location of the job (e.g., city, country, or remote).")]
    public string Location { get; set; }

    [Description("A list of duties and tasks the candidate is expected to perform in this role.")]
    public List<string> Responsibilities { get; set; }

    [Description("A list of qualifications, skills, or experience required or preferred for the job.")]
    public List<string> Requirements { get; set; }
  }
}
