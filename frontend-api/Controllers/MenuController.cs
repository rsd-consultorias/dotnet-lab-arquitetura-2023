using FrontEndAPI.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MenuController : Controller
{
    /// <summary>
    /// Retorna a estrutura de menu
    /// </summary>
    [HttpGet()]
    public IEnumerable<MenuViewModel>? Get()
    {
        var menus = new List<MenuViewModel>();

        for (int i = 0; i < 4; i++)
        {
            var menu = new MenuViewModel();
            var subMenus = new List<MenuViewModel>();

            menu.Display = $"Menu {i}";
            menu.Id = i;
            menu.SubMenus = subMenus;

            for (int j = 0; j < 4; j++)
            {
                var subMenu = new MenuViewModel();
                subMenu.Display = $"Sub Menu {j}";
                subMenu.Id = j;
                subMenu.Target = new List<string>() { "dashboard", $"{j}" };
                subMenus.Add(subMenu);
            }
            menus.Add(menu);
        }

        return menus;
    }
}
