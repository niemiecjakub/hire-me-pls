using HireMePls.Interfaces;
using HireMePls.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireMePls.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobController : ControllerBase
  {

    private readonly ILogger<JobController> _logger;
    private readonly IJobService _jobService;

    public JobController(ILogger<JobController> logger, IJobService jobService)
    {
      _logger = logger;
      _jobService = jobService;
    }

    [HttpPost(Name = "job")]
    [ProducesResponseType(200, Type = typeof(JobDocument))]
    public async Task<ActionResult<JobDocument>> GetJobData([FromBody] string jobUrl)
    {
      try
      {
        _logger.LogInformation($"Getting job data from: {jobUrl}");
        var job = await _jobService.GetJobDocumentAsync(jobUrl);
        return Ok(job);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message, ex);
        return BadRequest(ex.Message);
      }
    }
  }
}
