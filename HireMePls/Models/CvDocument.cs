using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents a complete CV document, including personal details, education, work experience, skills, and other optional sections.")]
  public class CvDocument : CoreCvDocument
  {
    [Description("Basic personal information such as name, contact details, and address.")]
    public PersonalDetails PersonalDetails { get; set; }
  }
}
