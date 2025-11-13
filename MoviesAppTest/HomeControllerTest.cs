using Microsoft.AspNetCore.Mvc;
using MoviesApp.Controllers;

namespace MoviesAppTest;

public class HomeControllerTest
{
    [Fact]
    public void Index_ReturnsView()
    {
        var controller =  new HomeController();
        var result = controller.Index();
        
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void About_ReturnsView()
    {
        var controller = new HomeController();
        var result = controller.About();
        Assert.IsType<ViewResult>(result);
    }
}