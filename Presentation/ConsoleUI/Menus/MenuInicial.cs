using Presentation.Utils;
using Domain.Enums;
namespace Presentation.ConsoleUI.Menus;
public class MenuInicial : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    public MenuInicial(Manager manager, Helper helper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void Redirecionar()
    {
        EscrevendoEstrutura();
        AllEnums.Teclas tecla = ReescritaParcial();
        if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuInicial.Cadastro)
        {
            manager.ApagarMenu();

        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuInicial.Login)
        {
            manager.ApagarMenu();
        }
        else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.MenuInicial.Sair)
        {
            helper.CursorPosition(0, Enum.GetValues(typeof(AllEnums.MenuInicial)).Length + 3);
            Environment.Exit(0);
        }
    }
}