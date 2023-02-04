using FrontEndAPI.ViewModels;
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
        foreach(var item in this.User.Claims) {
            Console.WriteLine($"{item.Type}:  {item.Value}");
        }
        var menus = new List<MenuViewModel>();
        var i = 0;

        menus.Add(new MenuViewModel(i++, "Cadastros")
        .AddSubMenu(new MenuViewModel(i++, "Funcionários", new List<string> { "cadastros/funcionarios" }))
        );

        menus.Add(new MenuViewModel(i++, "Processos")
        );

        menus.Add(new MenuViewModel(i++, "Relatórios")
        );

        menus.Add(new MenuViewModel(i++, "Integrações")
        );

        menus.Add(new MenuViewModel(i++, "Configurações")
        );

        return menus;
    }
}
