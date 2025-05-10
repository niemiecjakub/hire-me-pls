using HireMePls.Interfaces;
using HireMePls.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireMePls.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CvController : ControllerBase
  {
    private readonly ILogger<CvController> _logger;
    private readonly ICvService _cvService;

    public CvController(ILogger<CvController> logger, ICvService cvService)
    {
      _logger = logger;
      _cvService = cvService;
    }

    [HttpPost(Name = "cv")]
    [ProducesResponseType(200, Type = typeof(CvDocument))]
    public async Task<ActionResult<CvDocument>> GetCvData(IFormFile file)
    {
      try
      {
        if (file == null || file.Length == 0)
        {
          var message = "No file uploaded.";
          _logger.LogWarning(message);
          return BadRequest(message);
        }

        if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
        {
          var message = "Only PDF files are allowed.";
          _logger.LogWarning(message);
          return BadRequest(message);
        }

        _logger.LogInformation($"Getting cv data from: {file.Name}");
        var cv = await _cvService.GetCvDocumentAsync(file);
        return Ok(cv);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message, ex);
        return BadRequest(ex.Message);
      }
    }
  }
}
