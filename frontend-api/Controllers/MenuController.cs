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
        var i = 0;

        var m1 = new MenuViewModel(i, "Cadastros")
        .AddSubMenu(new MenuViewModel(i++, $"Cadastro {i}", new List<string> { "/home" }))
        .AddSubMenu(new MenuViewModel(i++, $"Cadastro {i}", new List<string> { "/dashboard" }))
        .AddSubMenu(new MenuViewModel(i++, $"Cadastro {i}", new List<string> { "/configuracoes" }));

        var m2 = new MenuViewModel(i++, "Processos")
        .AddSubMenu(new MenuViewModel(i++, $"Processos {i}", new List<string> { "/processos" }))
        .AddSubMenu(new MenuViewModel(i++, $"Processos {i}", new List<string> { "/processos" }))
        .AddSubMenu(new MenuViewModel(i++, $"Processos {i}", new List<string> { "/processos" }));

        var m4 = new MenuViewModel(i++, "Relatórios")
        .AddSubMenu(new MenuViewModel(i++, $"Relatórios {i}", new List<string> { "/relatorios" }))
        .AddSubMenu(new MenuViewModel(i++, $"Relatórios {i}", new List<string> { "/relatorios" }))
        .AddSubMenu(new MenuViewModel(i++, $"Relatórios {i}", new List<string> { "/relatorios" }));

        var m5 = new MenuViewModel(i++, "Integrações")
        .AddSubMenu(new MenuViewModel(i++, $"Integrações {i}", new List<string> { "/integracoes" }))
        .AddSubMenu(new MenuViewModel(i++, $"Integrações {i}", new List<string> { "/integracoes" }))
        .AddSubMenu(new MenuViewModel(i++, $"Integrações {i}", new List<string> { "/integracoes" }));

        var m3 = new MenuViewModel(i++, "Configurações")
        .AddSubMenu(new MenuViewModel(i++, $"Configurações {i}", new List<string> { "/configuracoes" }))
        .AddSubMenu(new MenuViewModel(i++, $"Configurações {i}", new List<string> { "/configuracoes" }))
        .AddSubMenu(new MenuViewModel(i++, $"Configurações {i}", new List<string> { "/configuracoes" }));

        menus.Add(m1);
        menus.Add(m2);
        menus.Add(m4);
        menus.Add(m5);
        menus.Add(m3);

        // var menu1 = new MenuViewModel();
        // var subMenus1 = new List<MenuViewModel>();

        // menu1.Display = $"Menu 0";
        // menu1.Id = 0;
        // menu1.SubMenus = subMenus1;
        // var subMenu1 = new MenuViewModel();
        // subMenu1.Display = $"Sub Menu 1";
        // subMenu1.Id = 1;
        // subMenu1.Target = new List<string>() { "home" };
        // subMenus1.Add(subMenu1);

        // menus.Add(menu1);

        // for (int i = 1; i < 4; i++)
        // {
        //     var menu = new MenuViewModel();
        //     var subMenus = new List<MenuViewModel>();

        //     menu.Display = $"Menu {i}";
        //     menu.Id = i;
        //     menu.SubMenus = subMenus;

        //     for (int j = 0; j < 4; j++)
        //     {
        //         var subMenu = new MenuViewModel();
        //         subMenu.Display = $"Sub Menu {j}";
        //         subMenu.Id = j;
        //         subMenu.Target = new List<string>() { "dashboard", $"{j}" };
        //         subMenus.Add(subMenu);
        //     }
        //     menus.Add(menu);
        // }

        return menus;
    }
}
