using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Contains essential contact and identity information for the individual.")]
  public class PersonalDetails
  {
    [Description("Full name of the individual.")]
    public string Name { get; set; }

    [Description("Primary phone number for contact.")]
    public string Phone { get; set; }

    [Description("Primary email address for correspondence.")]
    public string Email { get; set; }

    [Description("City, region, or country of residence.")]
    public string Location { get; set; }

    [Description("A collection of labeled links such as LinkedIn, GitHub, portfolio, or personal website.")]
    public List<Link> Links { get; set; }
  }
}
