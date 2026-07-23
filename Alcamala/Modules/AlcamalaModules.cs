using System.Runtime.InteropServices.JavaScript;

namespace Alcamala.Modules;

public partial class AlcamalaModules
{
    public static async Task ImportModuleAsync() => await JSHost.ImportAsync(nameof(AlcamalaModules), "/js/alcamala.modules.js");

    [JSExport]
    public static void Test(string test)
    {
        // Test - needs a JSExport method for the js file to not throw an error.
    }
}
