using FluentAssertions;
using Htmx.Oob.Example.Controllers;
using Htmx.Oob.Example.Pages;
using Htmx.Oob.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

namespace Htmx.Oob.Test;

public class Tests
{
    public static IEnumerable<object?[]> Swaps = new List<object?[]>()
    {
        new object?[] { null, "true" },
        new object?[] { "true", "true" },
        new object?[] { "beforebegin", "beforebegin" },
        new object?[] { "afterbegin", "afterbegin" },
        new object?[] { "beforeend", "beforeend" },
        new object?[] { "afterend", "afterend" },
        new object?[] { "outerHTML", "outerHTML" },
        new object?[] { "innerHTML", "innerHTML" },
        new object?[] { "none", "none" },
        new object?[] { "delete", "delete" },
        new object?[] { "delete:#123", "delete:#123" },
    };

    [Theory]
    [MemberData(nameof(Swaps))]
    public void ControllerPartialTests(string? input, string swap)
    {
        var controller = new TestController();
        var result = controller.Partial(input);

        var model = result.Should().BeOfType<PartialViewResult>().Which.Model.Should().BeOfType<HtmxOobBuilder>()
                          .Subject;
        model.MainResult.Should().BeOfType<PartialViewResult>();
        model.OobItems.Should().HaveCount(1);
        var oobItem = model.OobItems.First();

        oobItem.Should().BeOfType<OobPartial>().Which.Swap.Should().Be(swap);
    }

    [Theory]
    [MemberData(nameof(Swaps))]
    public void ControllerViewComponentsTests(string? input, string swap)
    {
        var controller = new TestController();
        var result = controller.ViewComponentAction(input);

        var model = result.Should().BeOfType<PartialViewResult>().Which.Model.Should().BeOfType<HtmxOobBuilder>()
                          .Subject;

        model.MainResult.Should().BeOfType<ViewComponentResult>();
        model.OobItems.Should().HaveCount(1);
        var oobItem = model.OobItems.First();

        oobItem.Should().BeOfType<OobViewComponent>().Which.Swap.Should().Be(swap);
    }

    [Theory]
    [MemberData(nameof(Swaps))]
    public void PagePartialTests(string? input, string swap)
    {
        var httpContext = new DefaultHttpContext();
        var modelState = new ModelStateDictionary();
        var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
        var modelMetadataProvider = new EmptyModelMetadataProvider();
        var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        var pageContext = new PageContext(actionContext)
        {
            ViewData = viewData
        };
        var page = new TestPage()
        {
            MetadataProvider = new EmptyModelMetadataProvider(),
            PageContext = pageContext,
            TempData = tempData,
            Url = new UrlHelper(actionContext)
        };

        var result = page.OnGetPartial(input);

        var model = result.Should().BeOfType<PartialViewResult>().Which.Model.Should().BeOfType<HtmxOobBuilder>()
                          .Subject;
        model.MainResult.Should().BeOfType<PartialViewResult>();
        model.OobItems.Should().HaveCount(1);
        var oobItem = model.OobItems.First();

        oobItem.Should().BeOfType<OobPartial>().Which.Swap.Should().Be(swap);
    }

    [Theory]
    [MemberData(nameof(Swaps))]
    public void PageViewComponentsTests(string? input, string swap)
    {
        var httpContext = new DefaultHttpContext();
        var modelState = new ModelStateDictionary();
        var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
        var modelMetadataProvider = new EmptyModelMetadataProvider();
        var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        var pageContext = new PageContext(actionContext)
        {
            ViewData = viewData
        };
        var page = new TestPage()
        {
            MetadataProvider = new EmptyModelMetadataProvider(),
            PageContext = pageContext,
            TempData = tempData,
            Url = new UrlHelper(actionContext)
        };

        var result = page.OnGetViewComponent(input);

        var model = result.Should().BeOfType<PartialViewResult>().Which.Model.Should().BeOfType<HtmxOobBuilder>()
                          .Subject;

        model.MainResult.Should().BeOfType<ViewComponentResult>();
        model.OobItems.Should().HaveCount(1);
        var oobItem = model.OobItems.First();

        oobItem.Should().BeOfType<OobViewComponent>().Which.Swap.Should().Be(swap);
    }
}
