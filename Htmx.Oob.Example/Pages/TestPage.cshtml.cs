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
        return Partial("_TestPartial")
               .WithOob()
               .AddPartial("_TestPartial", swap ?? "true").Build();
    }

    public IActionResult OnGetViewComponent(string? swap)
    {
        return ViewComponent("Test")
               .WithOob()
               .AddViewComponent("Test", swap ?? "true").Build();
    }
}
