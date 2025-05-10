namespace HireMePls.Interfaces
{
  public interface IWebScrapeService
  {
    public Task<string> GetPageContent(string url);
  }
}
