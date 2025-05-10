namespace HireMePls.Interfaces
{
  public interface IWebScrapeService
  {
    public Task<string> GetPageContentAsync(string url);
  }
}
