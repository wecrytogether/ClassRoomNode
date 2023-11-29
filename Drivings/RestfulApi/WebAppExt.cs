using Microsoft.AspNetCore.Builder;

namespace RestfulApi;

public static class WebAppExt
{
    public static WebApplication UseRestfulApiConfigurations(this WebApplication app)
    {
        app.UseHttpsRedirection();
        
        app.MapControllers();
        
        return app;
    }
}