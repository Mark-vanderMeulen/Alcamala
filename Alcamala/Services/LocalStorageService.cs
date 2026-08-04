using Microsoft.JSInterop;

namespace Alcamala.Services;

public class LocalStorageService(IJSRuntime jsRuntime)
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;

    public ValueTask SetItemAsync(string key, string value) => _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
    public ValueTask<string?> GetItemAsync(string key) => _jsRuntime.InvokeAsync<string?>("localStorage.getItem", key);

    public ValueTask SetCultureAsync(string culture) => SetItemAsync("culture", culture);
    public ValueTask<string?> GetCultureAsync() => GetItemAsync("culture");
}
