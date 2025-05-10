using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents a custom section in the CV, such as Certifications, Awards, Volunteer Work, or Hobbies.")]
  public class OtherSection
  {
    [Description("The title of the custom section (e.g., 'Certifications', 'Projects', 'Awards').")]
    public string Title { get; set; }

    [Description("An optional short paragraph summarizing the section's context or purpose.")]
    public string? Description { get; set; }

    [Description("A list of bullet points or descriptive items related to the section.")]
    public List<string> Details { get; set; }
  }
}
