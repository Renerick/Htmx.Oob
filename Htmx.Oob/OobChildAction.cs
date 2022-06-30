using Htmx.Oob.Items;

namespace Htmx.Oob;

public record OobChildAction(string Name, object? Arguments, string Swap) : IOobItem;
