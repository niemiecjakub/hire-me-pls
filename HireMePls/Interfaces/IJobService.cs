using HireMePls.Models;

namespace HireMePls.Interfaces
{
  public interface IJobService
  {
    public Task<JobDocument> GetJobDocument(string webPageContent);
  }
}
