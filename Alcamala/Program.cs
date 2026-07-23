using Alcamala.Modules;
using Alcamala.Services;
using Fireblaze.App;
using Fireblaze.Auth;
using Fireblaze.Auth.Extensions;
using Fireblaze.Firestore;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Alcamala;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddAuthorizationCore();
        builder.Services.AddFireblazeAuth<FirebaseAuthenticationStateProvider>();

        var host = builder.Build();

        await AlcamalaModules.ImportModuleAsync();
        await InitializeFireblazeAsync();

        await host.RunAsync();
    }

    private static async Task InitializeFireblazeAsync()
    {
        await FireblazeApp.InitializeAsync(new FirebaseConfig
        {
            ApiKey = "AIzaSyCKwtEKLNo_svyduP_LhfgYah2yCCupRzs",
            AuthDomain = "alcamala-firebase.firebaseapp.com",
            DatabaseURL = "https://alcamala-firebase-default-rtdb.europe-west1.firebasedatabase.app",
            ProjectId = "alcamala-firebase",
            StorageBucket = "alcamala-firebase.firebasestorage.app",
            MessagingSenderId = "961717907605",
            AppId = "1:961717907605:web:37f47eae4c67d6e0f12b9c",
            MeasurementId = "G-918DC7JXKZ"
        });

        await FireblazeAuth.InitializeAsync();

        await FireblazeFirestore.InitializeAsync();
    }
}
