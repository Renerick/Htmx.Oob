using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Htmx.Oob;

public static class Extensions
{
    public static HtmxOobBuilder WithOob(this PartialViewResult partialViewResult)
    {
        return new HtmxOobBuilder(partialViewResult);
    }

    public static HtmxOobBuilder WithOob(this ViewComponentResult viewComponentResult)
    {
        return new HtmxOobBuilder(viewComponentResult);
    }

    public static HtmxOobBuilder WithOob(this OkResult _)
    {
        return new HtmxOobBuilder();
    }

    public static PartialViewResult OobView(this Controller controller, HtmxOobBuilder model)
    {
        return controller.PartialView("OobView", model);
    }

    public static PartialViewResult OobView(this PageModel controller, HtmxOobBuilder model)
    {
        return controller.Partial("OobView", model);
    }
}
