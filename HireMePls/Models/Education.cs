using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents an educational qualification, including degree, institution, field of study, and duration.")]
  public class Education
  {
    [Description("The academic degree obtained.")]
    public string Degree { get; set; }

    [Description("The name of the educational institution.")]
    public string Institution { get; set; }

    [Description("The geographic location of the institution (city, country).")]
    public string Location { get; set; }

    [Description("Optional description of the educational experience, such as honors, thesis, or notable coursework.")]
    public string Description { get; set; }

    [Description("The major or field of study, such as Computer Science or Business Administration.")]
    public string FieldOfStudy { get; set; }

    [Description("The start date of the education period.")]
    public string? BeginDate { get; set; }

    [Description("The end date of the education period, if applicable.")]
    public string? EndDate { get; set; }
  }
}
