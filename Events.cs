using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace debounced_blazor
{
    public static class InputDebounce
    {
        public static async Task DebounceEvent(
            this IJSRuntime jsRuntime, 
            ElementReference element, 
            string eventName, 
            TimeSpan delay)
    {
        await using var module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./events.js");
        await module.InvokeVoidAsync("debounceEvent", element, eventName, (long)delay.TotalMilliseconds);
    }

    public static async Task ThrottleEvent(
        this IJSRuntime jsRuntime, 
        ElementReference element, 
        string eventName, 
        TimeSpan delay)
    {
        await using var module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./events.js");
        await module.InvokeVoidAsync("throttleEvent", element, eventName, (long)delay.TotalMilliseconds);
    }
    }
}