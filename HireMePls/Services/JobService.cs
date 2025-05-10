using HireMePls.Interfaces;
using HireMePls.Models;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text.Json;

namespace HireMePls.Services
{
  public class JobService : IJobService
  {
    private IWebScrapeService _webScrapeService;
    private Kernel _kernel;

    public JobService(IWebScrapeService webScrapeService, Kernel kernel)
    {
      _webScrapeService = webScrapeService;
      _kernel = kernel;
    }

    private string _systemPrompt =
    $"""
          # Role
          You are an intelligent web scraping agent designed to extract structured job information from the HTML content of job listing web pages.

          # Objective
          Your task is to analyze the provided content and return job-related details in clean JSON format.

          # Instructions:
          - Extract the following fields if available:
            - Job title
            - Job summary (about the job)
            - Company name
            - Location
            - Responsibilities
            - Requirements
          - If any field is not found, use `null` as its value.

          # Notes
          - Do not change language
         """;

    public async Task<JobDocument> GetJobDocument(string jobOfferUrl)
    {
      var pageContent = await _webScrapeService.GetPageContent(jobOfferUrl);
      IChatCompletionService chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
      ChatMessageContent jobDetails = await chatCompletionService.GetChatMessageContentAsync(pageContent, new OpenAIPromptExecutionSettings()
      {
        ChatSystemPrompt = _systemPrompt,
        ResponseFormat = typeof(JobDocument)
      });

      return JsonSerializer.Deserialize<JobDocument>(jobDetails.Content);
    }
  }
}
