namespace LabArquitetura.ViewModels
{

    public class MenuViewModel
    {
        public int Id { get; set; }
        public string? Display { get; set; }
        public List<string>? Target { get; set; }
        public IEnumerable<MenuViewModel>? SubMenus { get; set; }

        public MenuViewModel()
        {
            SubMenus = new List<MenuViewModel>();
        }

        public MenuViewModel(int id, string display, List<string>? target = null)
        {
            SubMenus = new List<MenuViewModel>();
            Id = id;
            Display = display;
            Target = target;
        }

        public MenuViewModel AddSubMenu(MenuViewModel subMenu)
        {
            ((List<MenuViewModel>)SubMenus!).Add(subMenu);
            return this;
        }
    }
}