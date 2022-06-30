using Microsoft.AspNetCore.Mvc;

namespace Htmx.Oob.Example.Views.Shared.Components;


public class TestViewComponent : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync(string? swap)
    {
        return Task.FromResult<IViewComponentResult>(View(new { Swap = swap }));
    }
}
