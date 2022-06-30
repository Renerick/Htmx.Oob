using Htmx.Oob.Items;
using Microsoft.AspNetCore.Mvc;

namespace Htmx.Oob;

public class HtmxOobBuilder
{
    public List<IOobItem> OobItems { get; init; }

    public object? MainResult { get; init; }

    public HtmxOobBuilder()
    {
        OobItems = new List<IOobItem>();
        MainResult = null;
    }

    public HtmxOobBuilder(PartialViewResult main) : this()
    {
        MainResult = main;
    }

    public HtmxOobBuilder(ViewComponentResult main) : this()
    {
        MainResult = main;
    }

    public HtmxOobBuilder AddPartial(string partial, string swap = "true")
    {
        OobItems.Add(new OobPartial(partial, null, swap));
        return this;
    }

    public HtmxOobBuilder AddPartial(string partial, object? model, string swap = "true")
    {
        OobItems.Add(new OobPartial(partial, model, swap));
        return this;
    }

    public HtmxOobBuilder AddViewComponent(string viewComponentName, string swap = "true")
    {
        OobItems.Add(new OobViewComponent(viewComponentName, null, swap));
        return this;
    }

    public HtmxOobBuilder AddViewComponent(string viewComponentName, object? args, string swap = "true")
    {
        OobItems.Add(new OobViewComponent(viewComponentName, args, swap));
        return this;
    }

    public HtmxOobBuilder AddViewComponent(Type viewComponentType, string swap = "true")
    {
        OobItems.Add(new OobViewComponent(viewComponentType, null, swap));
        return this;
    }

    public HtmxOobBuilder AddViewComponent(Type viewComponentType, object? args, string swap = "true")
    {
        OobItems.Add(new OobViewComponent(viewComponentType, args, swap));
        return this;
    }

    public HtmxOobBuilder AddDeleteOob(string id)
    {
        OobItems.Add(new OobDelete(id));
        return this;
    }
}
