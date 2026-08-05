using Alcamala.Services;
using Elysium.Components.Services;
using Elysium.Themes.Extensions;
using Elysium.Utilities.DeviceInfo;
using Elysium.Utilities.LocalStorage;
using Fireblaze;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace Alcamala;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddScoped<LocalStorageService>();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddFireblazeAuth<FirebaseAuthenticationStateProvider>();

        builder.Services.AddElysiumThemes();
        builder.Services.AddScoped<ElAppBarService>();
        builder.Services.AddScoped<DeviceInfoService>();

        var host = builder.Build();

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

        await SetCultureAsync(host.Services);

        await host.RunAsync();
    }

    private static async Task SetCultureAsync(IServiceProvider serviceProvider)
    {
        var localStorageService = serviceProvider.GetRequiredService<LocalStorageService>();
        var savedCultureName = await localStorageService.GetCultureAsync();

        if (!string.IsNullOrEmpty(savedCultureName))
        {
            try
            {
                var savedCulture = new CultureInfo(savedCultureName);

                CultureInfo.CurrentCulture = savedCulture;
                CultureInfo.CurrentUICulture = savedCulture;
                CultureInfo.DefaultThreadCurrentCulture = savedCulture;
                CultureInfo.DefaultThreadCurrentUICulture = savedCulture;
            }
            catch (CultureNotFoundException) { }
        }
    }
}
