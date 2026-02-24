using Presentation.Utils;
using Domain.Enums;
namespace Presentation.ConsoleUI.Menus;
public class MenuEditarMaterias : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    public MenuEditarMaterias(Manager manager, Helper helper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void Redirecionar()
    {
        EscrevendoEstrutura();
        AllEnums.Teclas tecla = ReescritaParcial();
        if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.AlterarNome)
        {
            manager.ApagarMenu();
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.AlterarNota)
        {
            manager.ApagarMenu();
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.AlterarPeríodo)
        {
            manager.ApagarMenu();
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.ExcluirMaterias)
        {
            manager.ApagarMenu();
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.Voltar)
        {
            manager.ApagarMenu();
            manager.QtdInstanciadaMenus = 0;
            manager.Posicao = 0;
            manager.IniciarMenu = AllEnums.EscolherMenu.MenuMaterias;
        }
    }
}