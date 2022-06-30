using Microsoft.AspNetCore.Mvc;

namespace Htmx.Oob.Example.Controllers;

[Route("test-controller")]
public class TestController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/partial")]
    public IActionResult Partial(string? swap)
    {
        return this.OobView(
            PartialView("_TestPartial")
                .WithOob()
                .AddPartial("_TestPartial", swap ?? "true")
        );
    }

    [HttpGet("/vc")]
    public IActionResult ViewComponentAction(string? swap)
    {
        return this.OobView(
            ViewComponent("Test")
                .WithOob()
                .AddViewComponent("Test", swap ?? "true")
        );
    }
}
