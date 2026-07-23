using Alcamala.Models;
using Alcamala.Services;
using Microsoft.AspNetCore.Components;

namespace Alcamala.Pages;

public class BasePage : ComponentBase
{
    [Inject] public FirebaseAuthenticationStateProvider Auth { get; set; } = null!;

    protected AlcamalaUser CurrentUser => Auth.CurrentUser ?? SignOutAndThrow();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (Auth.CurrentUser == null)
        {
            Auth.SignOut();
            return;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (Auth.CurrentUser == null)
        {
            Auth.SignOut();
            return;
        }
    }

    private AlcamalaUser SignOutAndThrow()
    {
        Auth.SignOut();

        throw new Exception("User not logged in");
    }
}
