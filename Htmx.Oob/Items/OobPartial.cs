namespace Htmx.Oob.Items;

public record OobPartial(string ViewName, object? Model = null, string Swap = "true") : IOobItem;
