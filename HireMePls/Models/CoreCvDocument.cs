using System.ComponentModel;

namespace HireMePls.Models
{
  public class CoreCvDocument
  {
    [Description("A brief personal summary or professional introduction.")]
    public string? AboutMe { get; set; }

    [Description("A list of the individual's educational background, such as schools, degrees, and dates attended.")]
    public List<Education> Education { get; set; }

    [Description("A chronological list of past job experiences, including roles, responsibilities, and duration.")]
    public List<WorkExperience> WorkExperience { get; set; }

    [Description("A list of key technical or soft skills relevant to the individual's career goals.")]
    public List<string> Skills { get; set; }

    [Description("Languages spoken and level of proficiency.")]
    public List<string> Languages { get; set; }

    [Description("Additional custom sections, such as certifications, publications, hobbies, or volunteer work.")]
    public List<OtherSection> OtherSections { get; set; }
  }
}
