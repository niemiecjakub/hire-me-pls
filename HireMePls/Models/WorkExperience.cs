using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents a professional experience entry, including role, company, duration, and responsibilities.")]
  public class WorkExperience
  {
    [Description("The job title or position held by the individual.")]
    public string JobTitle { get; set; }

    [Description("Optional summary or narrative of the role, team, or notable contributions.")]
    public string Description { get; set; }

    [Description("The name of the company or organization.")]
    public string Company { get; set; }

    [Description("The geographic location where the job was performed (e.g., city and country).")]
    public string Location { get; set; }

    [Description("The start date of the work period.")]
    public DateTime? BeginDate { get; set; }

    [Description("The end date of the education work, if applicable.")]
    public DateTime? EndDate { get; set; }

    [Description("A list of key duties, achievements, or responsibilities associated with the role.")]
    public List<string> Responsibilities { get; set; }
  }
}
