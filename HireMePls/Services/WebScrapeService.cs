using HireMePls.Interfaces;
using HtmlAgilityPack;

namespace HireMePls.Services
{
  public class WebScrapeService : IWebScrapeService
  {
    public async Task<string> GetPageContent(string url)
    {
      var html = await new HttpClient().GetStringAsync(url);

      var doc = new HtmlDocument();
      doc.LoadHtml(html);

      doc.DocumentNode
          .Descendants()
          .Where(n => n.Name == "script" || n.Name == "style")
          .ToList()
          .ForEach(n => n.Remove());

      return string.Join("\n",
          doc.DocumentNode.DescendantsAndSelf()
          .Where(n => !n.HasChildNodes && !string.IsNullOrWhiteSpace(n.InnerText))
          .Select(n => n.InnerText.Trim()));
    }
  }
}
