using Application.Service;
using Domain.Enums;
using Presentation.ConsoleUI.Menus;
using Presentation.Utils;
namespace Presentation.ConsoleUI;
public class Manager
{
    public AllEnums.EscolherMenu IniciarMenu { get; set; }
    private Helper helper;
    public Manager(Helper helper)
    {
        this.helper = helper;
    }
    public int Posicao;
    public int QtdInstanciadaMenus;
    public void ExecutarMenu()
    {
        if (IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            var MenuInicial = new MenuInicial(this, helper);
            MenuInicial.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            var MenuMaterias = new MenuMaterias(this, helper);
            MenuMaterias.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            var MenuEditarMaterias = new MenuEditarMaterias(this, helper);
            MenuEditarMaterias.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            var Cadastro = new Cadastro(this, helper);
            Cadastro.UserPassword();
        }
        else
        {
            //Login
        }
    }
    public void ApagarMenu()
    {
        if (IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            AuxuliarApagarMenu(typeof(AllEnums.MenuInicial));
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            AuxuliarApagarMenu(typeof(AllEnums.Menumaterias));
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            AuxuliarApagarMenu(typeof(AllEnums.MenuEditarMaterias));
        }
    }
    public void AuxuliarApagarMenu(Type typeEnum)
    {
        int y = Enum.GetValues(typeEnum).Length + 1;
        int x = 40;
        while (true)
        {
            helper.CursorPosition(x, y);
            Thread.Sleep(10);
            Console.Write(" ");
            if (x == 0)
            {
                x = 40;
                y--;
            }
            if (y < 0)
            {
                break;
            }
            x--;
        }
    }
}