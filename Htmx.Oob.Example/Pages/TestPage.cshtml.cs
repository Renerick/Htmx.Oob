using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Htmx.Oob.Example.Pages;

public class TestPage : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnGetPartial(string? swap)
    {
        return this.OobView(
            Partial("_TestPartial")
                .WithOob()
                .AddPartial("_TestPartial", swap ?? "true")
        );
    }

    public IActionResult OnGetViewComponent(string? swap)
    {
        return this.OobView(
            ViewComponent("Test")
                .WithOob()
                .AddViewComponent("Test", swap ?? "true")
        );
    }
}
