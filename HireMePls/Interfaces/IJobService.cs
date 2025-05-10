using HireMePls.Models;

namespace HireMePls.Interfaces
{
  public interface IJobService
  {
    public Task<JobDocument> GetJobDocumentAsync(string webPageContent);
  }
}
