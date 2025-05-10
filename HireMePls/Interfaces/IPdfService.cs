namespace HireMePls.Interfaces
{
  public interface IPdfService
  {
    public Task<string> ExtractContentAsync(IFormFile file);
  }
}
