using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Sumos.Webhook.MetaWebhook;

public static class MetaWebhookApi
{
    public static WebApplication MapMetaWebhookApi(this WebApplication app)
    {
        var group = app.MapGroup("/webhook/whatsapp");

        group.MapGet("/", (
            [FromQuery(Name = "hub.mode")] string mode,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.verify_token")] string verifyToken,
            [FromHeader(Name = "X-Hub-Signature-256")] string signature,
            IConfiguration configuration
        ) =>
        {
            if (
                string.IsNullOrEmpty(mode) ||
                string.IsNullOrEmpty(challenge) ||
                string.IsNullOrEmpty(verifyToken))
            {
                return Results.BadRequest();
            }

            return verifyToken != configuration["Meta:Whatsapp_Verify_Token"]
                ? Results.Unauthorized()
                : Results.Ok(challenge);
        });

        static bool VerifySignature(string payload, string signature, string secret)
        {
            var encoding = Encoding.UTF8;
            using var hmac = new HMACSHA256(encoding.GetBytes(secret));
            var hash = hmac.ComputeHash(encoding.GetBytes(payload));
            var computedSignature = $"sha256={Convert.ToHexStringLower(hash)}";
            return signature == computedSignature;
        }

        group.MapPost("/", async (
            [FromHeader(Name = "X-Hub-Signature-256")] string signature,
            HttpRequest request
        ) =>
        {
            app.Logger.LogInformation("Received signature: {signature}", signature);

            using var reader = new StreamReader(request.Body);
            var jsonString = await reader.ReadToEndAsync();
            var isValid = VerifySignature(jsonString, signature, app.Configuration["Meta:App_Secret"]!);
            if (!isValid)
            {
                return Results.Unauthorized();
            }

            var payload = JsonSerializer.Deserialize<WhatsAppWebhook>(jsonString);

            return Results.Ok("hi");
        });

        return app;
    }
}