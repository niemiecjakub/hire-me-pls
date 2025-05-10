using System.ComponentModel;

namespace HireMePls.Models
{
  [Description("Represents a hyperlink to an external resource, such as a social media profile, portfolio, or personal website.")]
  public class Link
  {
    [Description("The name or label for the link, such as 'LinkedIn', 'GitHub', or 'Portfolio'.")]
    public string Name { get; set; }

    [Description("The URL or web address that the link points to.")]
    public string Url { get; set; }
  }
}
