namespace Htmx.Oob.Items;

public record OobDelete(string Id) : IOobItem
{
    public string Swap => "delete";
}
