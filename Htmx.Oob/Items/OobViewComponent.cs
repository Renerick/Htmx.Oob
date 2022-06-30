using Microsoft.AspNetCore.Mvc;

namespace Htmx.Oob.Items;

[NonViewComponent]
public record OobViewComponent(string Swap = "true") : IOobItem
{
    public string? ViewComponentName { get; }

    public Type? ViewComponentType { get; }

    public object? Arguments { get; set; }

    public OobViewComponent(string viewComponentName, object? arguments = null, string swap = "true") : this(swap)
    {
        ViewComponentName = viewComponentName;
        Arguments = arguments;
    }

    public OobViewComponent(Type viewComponentType, object? arguments = null, string swap = "true") : this(swap)
    {
        ViewComponentType = viewComponentType;
        Arguments = arguments;
    }
}
