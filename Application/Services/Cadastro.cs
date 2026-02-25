using Presentation.ConsoleUI;
using Domain.Enums;
using Presentation.Utils;
using Presentation.ConsoleUI.Menus;
namespace Application.Service;
public class Cadastro : MenuBase
{
    private Manager manager;
    private Helper helper;
    public Cadastro(Manager manager,Helper helper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void /*(string usuario, string senha)*/ UserPassword()
    {
        manager.IniciarMenu = AllEnums.EscolherMenu.Cadastro;
        EscrevendoEstrutura();
    }
}