using Microsoft.AspNetCore.Mvc;

namespace ShippingCalculator.Api.Shipping;

public static class Api
{
    public static WebApplication UseShipping(this WebApplication app)
    {
        app.MapGet("/shipping", ([FromServices] TimeProvider clock) =>
        {
            var now = clock.GetLocalNow();
            if (now.Hour <= 16 && now.Hour >= 9)
            {
                return new { shipDate = now, message = "Jeff Was Here" };
            }
            else
            {
                return new { shipDate = now.AddDays(1), message = "Jeff Was Here" };
            }
        });

        return app;
    }
}
