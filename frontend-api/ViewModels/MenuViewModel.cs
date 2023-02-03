namespace FrontEndAPI.ViewModels;

public class MenuViewModel
{
    public int Id { get; set; }
    public string? Display { get; set; }
    public List<string>? Target { get; set; }
    public IEnumerable<MenuViewModel>? SubMenus { get; set; }
}