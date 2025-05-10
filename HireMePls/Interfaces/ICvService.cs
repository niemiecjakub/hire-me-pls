using HireMePls.Models;

namespace HireMePls.Interfaces
{
  public interface ICvService
  {
    public Task<CvDocument> GetCvDocumentAsync(IFormFile file);
  }
}
