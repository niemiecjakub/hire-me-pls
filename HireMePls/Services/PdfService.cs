using HireMePls.Interfaces;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace HireMePls.Services
{
  public class PdfService : IPdfService
  {
    public async Task<string> ExtractContentAsync(IFormFile file)
    {
      using var memoryStream = new MemoryStream();
      await file.CopyToAsync(memoryStream);
      memoryStream.Position = 0;

      using PdfDocument document = PdfDocument.Open(memoryStream);

      StringBuilder cvData = new StringBuilder();
      foreach (Page page in document.GetPages())
      {
        cvData.Append(page.Text);
        var images = page.GetImages();
        var links = page.GetHyperlinks();
      }

      return cvData.ToString();
    }
  }
}
