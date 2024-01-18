# Htmx.Oob

A response builder to add [htmx OOB](https://htmx.org/attributes/hx-swap-oob/) fragments to ASP.NET core responses.
Use it to add View Components and Partial views to your action result and
update corresponding parts of pages from a single response.

## How to use

After installing the package, use `OobView` extension method to create `OobView` partial and then
`WithOob` extension method to initialize `HtmxOobBuilder` instance.
To add fragments to it, use corresponding methods: `AddViewComponent`, `AddPartial` and `AddDeleteOob`.
The last one is a special case, used to simplify elements removal without rendering full fragment.

```csharp
// this example will result in two view components in the response, 
// one of which is out of band
return this.OobView(
    ViewComponent("Test")
        .WithOob()
        .AddViewComponent("Test")
);
```

Builder methods have overloads that match standard methods used to return ViewComponents/Partials
as action result, so you can pass arguments and view models as usual. They also accept `swap` argument,
which is `true` by default. This all works from controllers and Razor Pages handlers.

Your fragments must be modified to support the swap value. In case of partials, the value
is passed in the ViewData dictionary and can be accessed with `ViewData["Swap"]` or `ViewBag.Swap`

```html
<div hx-swap-oob="@ViewBag.Swap" id="partial-oob">
    Partial @(new Random().Next())
</div>
```

In case of View Components, the value will be passed as an argument of invoke method. You will have
to pass it to the view yourself

```csharp
public Task<IViewComponentResult> InvokeAsync(string? swap)
{
    return Task.FromResult<IViewComponentResult>(View(new { Swap = swap }));
}
```

Refer to [Example](Htmx.Oob.Example) project for more details on how to use it.

## How it works

Under the hood, the builder is used as a model of `OobView` partial. When rendered,
this partial renders all items of the builder as a single page.

## License

This repo is licensed under the terms of [MIT License](LICENSE)

-----

[htmx](https://github.com/bigskysoftware/htmx) is licensed under the terms of [BSD Zero-Clause License](https://github.com/bigskysoftware/htmx/blob/master/LICENSE)