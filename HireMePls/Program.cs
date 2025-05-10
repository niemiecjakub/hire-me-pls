using HireMePls.Interfaces;
using HireMePls.Services;
using Microsoft.SemanticKernel;

namespace HireMePls
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddSingleton<Kernel>(sp =>
      {
        var kernelBuilder = Kernel.CreateBuilder();
        kernelBuilder.AddOpenAIChatCompletion(
          modelId: builder.Configuration["OpenAI:ModelId"],
          apiKey: builder.Configuration["OpenAI:ApiKey"]);

        return kernelBuilder.Build();
      });

      builder.Services.AddScoped<IWebScrapeService, WebScrapeService>();
      builder.Services.AddScoped<IJobService, JobService>();
      builder.Services.AddScoped<IPdfService, PdfService>();
      builder.Services.AddScoped<ICvService, CvService>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
