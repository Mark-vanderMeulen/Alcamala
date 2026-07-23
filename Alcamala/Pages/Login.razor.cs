using Fireblaze.Auth.Services;
using Microsoft.AspNetCore.Components;

namespace Alcamala.Pages;

public partial class Login// : IDisposable
{
    [Inject] public required FirebaseAuthService FirebaseAuthService { get; init; }
    [Inject] public required NavigationManager NavigationManager { get; init; }
    [SupplyParameterFromQuery] public string? ReturnUrl { get; set; }

    private string _email = string.Empty;
    private string _password = string.Empty;

    //protected override void OnInitialized()
    //{
    //    FirebaseAuthModule.FirebaseAuthStateChanged += OnFirebaseAuthStateChanged;
    //}

    //private void OnFirebaseAuthStateChanged(object? _, FirebaseAuthStateChangedEventArgs e)
    //{
    //    if (e.FirebaseUser is IFirebaseUser firebaseUser)
    //    {
    //        NavigationManager.NavigateTo("/drinks");
    //    }
    //}

    private async Task TryLogin()
    {
        await FirebaseAuthService.TrySignInWithEmailAndPassword(_email, _password);

        var target = "/drinks";

        if (!string.IsNullOrWhiteSpace(ReturnUrl) && Uri.IsWellFormedUriString(ReturnUrl, UriKind.Relative))
        {
            target = ReturnUrl;
        }

        NavigationManager.NavigateTo(target);
    }

    //public void Dispose()
    //{
    //    FirebaseAuthModule.FirebaseAuthStateChanged -= OnFirebaseAuthStateChanged;
    //}
}
