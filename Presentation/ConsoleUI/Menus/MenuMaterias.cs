using Presentation.Utils;
namespace Presentation.ConsoleUI.Menus;
public class MenuMaterias : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    public MenuMaterias(Manager manager, Helper helper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void Redirecionar()
    {
        EscrevendoEstrutura();
        Domain.Enums.AllEnums.Teclas tecla = ReescritaParcial();
        if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.VerMaterias)
        {
            ApagarMenu();
        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.AdicionarMaterias)
        {
            ApagarMenu();
        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.EditarMaterias)
        {
            ApagarMenu();
            manager.QtdInstanciadaMenus = 0;
            manager.Posicao = 0;
            manager.IniciarMenu = Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias;
        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.Sair)
        {
            helper.CursorPosition(0, Enum.GetValues(typeof(Domain.Enums.AllEnums.Menumaterias)).Length + 3);
            Environment.Exit(0);
        }
    }
}