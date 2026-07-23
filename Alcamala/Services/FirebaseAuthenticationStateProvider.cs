using Alcamala.Models;
using Fireblaze.Auth.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Alcamala.Services;

public class FirebaseAuthenticationStateProvider : AuthenticationStateProvider, IFirebaseAuthenticationStateProvider
{
    private static ClaimsPrincipal Anonymous => new(new ClaimsIdentity(Array.Empty<Claim>(), string.Empty));

    private ClaimsPrincipal _claimsPrincipal = Anonymous;
    
    public AlcamalaUser? CurrentUser { get; private set; }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_claimsPrincipal));
    }

    public void AuthenticateUser(IFirebaseUser firebaseUser)
    {
        IEnumerable<Claim> claims =
        [
            new Claim(ClaimTypes.Sid, firebaseUser.Uid),
            new Claim(ClaimTypes.Email, firebaseUser.Email ?? string.Empty)
        ];

        _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, nameof(FirebaseAuthenticationStateProvider)));

        CurrentUser = new AlcamalaUser
        {
            Uid = firebaseUser.Uid,
            Email = firebaseUser.Email
        };

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void SignOut()
    {
        _claimsPrincipal = Anonymous;
        CurrentUser = null;

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
