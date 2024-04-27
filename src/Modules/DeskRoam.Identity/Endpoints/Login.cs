using FastEndpoints;

namespace DeskRoam.Identity.Endpoints;

public class Login : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("/api/identity/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        throw new ApplicationException();
        await SendAsync(new LoginResponse("Test"));
    }
}

public record LoginRequest(string Username, string Password);
public record LoginResponse(string Message);