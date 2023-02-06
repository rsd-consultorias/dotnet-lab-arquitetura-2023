using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabArquitetura.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ILogger _logger;

        public MenuController(ILogger<OnboardController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna a estrutura de menu
        /// </summary>
        [HttpGet()]
        public IEnumerable<MenuViewModel>? Get()
        {
            List<MenuViewModel> menus = new();
            int i = 0;

            menus.Add(new MenuViewModel(i++, "Cadastros")
                .AddSubMenu(new MenuViewModel(i++, "Funcionários", new List<string> { "cadastros/funcionarios" }))
                );

            menus.Add(new MenuViewModel(i++, "Processos")
                .AddSubMenu(new MenuViewModel(i++, "Processo Longo", new List<string> { "processos/processo-longo" }))
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
}