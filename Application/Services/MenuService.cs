using Presentation.ConsoleUI;
using Domain.Enums;
using Presentation.Utils;
namespace Application.Service;
public class MenuService
{
    private Manager manager;
    private Helper helper;
    public MenuService(Manager manager, Helper helper)
    {
        this.manager = manager;
        this.helper = helper;
    }
}