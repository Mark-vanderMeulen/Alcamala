using Elysium.Components.Services;

namespace Alcamala.Pages;

public partial class Weight : BasePage
{
    protected override void OnInitialized()
    {
        base.OnInitialized();

        AppBarService.SetConfig(new ElAppBarConfig("Weight"));
    }
}
