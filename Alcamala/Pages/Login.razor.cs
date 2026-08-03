using Fireblaze.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Alcamala.Pages;

public partial class Login : IDisposable
{
    [Inject] public required FirebaseAuthService FirebaseAuthService { get; init; }
    [Inject] public required NavigationManager NavigationManager { get; init; }
    [SupplyParameterFromQuery] public string? ReturnUrl { get; set; }

    private string _email = string.Empty;
    private string _password = string.Empty;
    private bool _rememberMe;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        FirebaseAuthService.FirebaseAuthStateChanged += OnFirebaseAuthStateChanged;
    }

    private async Task TryLoginAsync()
    {
        await FirebaseAuthService.TrySignInWithEmailAndPassword(_email, _password, _rememberMe);

        var target = "/drinks";

        if (!string.IsNullOrWhiteSpace(ReturnUrl) && Uri.IsWellFormedUriString(ReturnUrl, UriKind.Relative))
        {
            target = ReturnUrl;
        }

        NavigationManager.NavigateTo(target);
    }

    private void OnFirebaseAuthStateChanged(object? _, FirebaseAuthStateChangedEventArgs e)
    {
        if (e.FirebaseUser is IFirebaseUser firebaseUser)
        {
            NavigationManager.NavigateTo("/drinks");
        }
    }

    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            await TryLoginAsync();
        }
    }

    public void Dispose()
    {
        FirebaseAuthService.FirebaseAuthStateChanged -= OnFirebaseAuthStateChanged;
    }
}
