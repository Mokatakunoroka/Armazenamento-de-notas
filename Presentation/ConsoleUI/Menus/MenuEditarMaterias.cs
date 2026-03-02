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
            helper.ApagarMenu(manager.IniciarMenu);
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.AlterarNota)
        {
            helper.ApagarMenu(manager.IniciarMenu);
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.AlterarPeríodo)
        {
            helper.ApagarMenu(manager.IniciarMenu);
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.ExcluirMaterias)
        {
            helper.ApagarMenu(manager.IniciarMenu);
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuEditarMaterias.Voltar)
        {
            helper.ApagarMenu(manager.IniciarMenu);
            manager.QtdInstanciadaMenus = 0;
            manager.Posicao = 0;
            manager.IniciarMenu = AllEnums.EscolherMenu.MenuMaterias;
        }
    }
}