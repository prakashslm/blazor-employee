using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDetails.App.Services;

namespace EmployeeDetails.App
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      // Since Blazor is running on the server, we can use an application service
      // to read the forecast data.
      services.AddSingleton<WeatherForecastService>();
      services.AddSingleton<EmployeeService>();
    }

    public void Configure(IBlazorApplicationBuilder app)
    {
      app.AddComponent<App>("app");
    }
  }
}
