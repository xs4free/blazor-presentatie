using Microsoft.AspNetCore.Components.Builder;

namespace BlazorWebAssembly
{
    public class Startup
    {
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
