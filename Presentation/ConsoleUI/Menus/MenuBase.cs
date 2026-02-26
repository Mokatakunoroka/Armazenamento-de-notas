using System.Runtime.InteropServices;
using Domain.Enums;
using Presentation.Utils;
namespace Presentation.ConsoleUI.Menus;
public class MenuBase
{
    private readonly Manager manager;
    private readonly Helper helper;
    public MenuBase(Manager manager, Helper helper)
    {
        this.manager = manager;
        this.helper = helper;
    }
    protected void EscreverEstruturaCorreta()
    {
        if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            EstruturaBase(typeof(AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            EstruturaBase(typeof(AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            EstruturaBase(typeof(AllEnums.MenuEditarMaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            EstruturaBase(typeof(AllEnums.Cadastro));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Login)
        {
            EstruturaBase(typeof(AllEnums.Login));
        }
        else
        {
            EstruturaBase(typeof(AllEnums.Periodo));
        }
    }
    private void EstruturaBase(Type qualEnum)
    {
        helper.Color(backColor: ConsoleColor.Black, letterColor: ConsoleColor.Yellow);
        helper.CursorPosition(0, 0);
        if (qualEnum == typeof(AllEnums.Cadastro) || qualEnum == typeof(AllEnums.Login))
        {
            Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 80));
            for (int i = 0; i < Enum.GetValues(qualEnum).Length; i++)
            {
                Console.WriteLine("|" + "|".PadLeft(79));
            }
            Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 80));
        }
        else
        {
            Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
            for (int i = 0; i < Enum.GetValues(qualEnum).Length; i++)
            {
                Console.WriteLine("|" + "|".PadLeft(39));
            }
            Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
        }
        Console.ResetColor();
    }
    public void EscrevendoEstrutura()
    {
        if (manager.QtdInstanciadaMenus == 0)
        {
            manager.QtdInstanciadaMenus++;
            EscreverEstruturaCorreta();
            if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.MenuInicial));
            }
            else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.Menumaterias));
            }
            else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.MenuEditarMaterias));
            }
            else if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro)
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.Cadastro));
            }
            else if (manager.IniciarMenu == AllEnums.EscolherMenu.Login)
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.Login));
            }
            else
            {
                AuxiliarEscreverOpcoes(typeof(AllEnums.Periodo));
            }
        }
    }
    private void AuxiliarEscreverOpcoes(Type typeEnum)
    {
        int y = 1;
        int indice = 0;
        foreach (KeyValuePair<string, string> item in helper.EnumCorrected(typeEnum))
        {
            if (manager.IniciarMenu != Domain.Enums.AllEnums.EscolherMenu.Cadastro && manager.IniciarMenu != Domain.Enums.AllEnums.EscolherMenu.Login)
            {
                SubAuxiliarOpcoes(indice, item, y, '.', typeEnum);
                y++;
                indice++;
            }
            else
            {
                SubAuxiliarOpcoes(indice, item, y, ':', typeEnum);
                y++;
                indice++;
            }
        }
    }
    private void SubAuxiliarOpcoes(int indice, KeyValuePair<string, string> item, int y, char final, Type qualEnum)
    {
        if (qualEnum == typeof(AllEnums.Cadastro) || qualEnum == typeof(AllEnums.Login))
        {
            if (manager.Posicao == indice) //opção selecionada
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
            else // Opção não selecionada
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
        }
        else
        {
            if (manager.Posicao == indice) //opção selecionada
            {
                helper.CursorPosition(2, y);
                helper.Color(ConsoleColor.Green, ConsoleColor.Red);
                Console.WriteLine($"> {item.Key}{final}");
                Console.ResetColor();
            }
            else // Opção não selecionada
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
        }
    }
    protected AllEnums.Teclas TeclaPressionada()
    {
        AllEnums.Teclas Tecla = Console.ReadKey(true).Key switch
        {
            ConsoleKey.UpArrow => AllEnums.Teclas.Subir,
            ConsoleKey.DownArrow => AllEnums.Teclas.Descer,
            ConsoleKey.Enter => AllEnums.Teclas.Enter,
            _ => AllEnums.Teclas.Nenhuma
        };
        //Preciso verificar o numero da poição atual e fazer alterações no this.posição
        if (Tecla == AllEnums.Teclas.Subir && manager.Posicao> 0)
        {
            manager.Posicao--;
        }
        else if (Tecla == AllEnums.Teclas.Descer && manager.Posicao < Enum.GetValues(AuxiliarTecla(manager.IniciarMenu.GetType())).Length - 1)
        {
            manager.Posicao++;
        }
        return Tecla;
    }
    private Type AuxiliarTecla(Type qualEnum)
    {
        if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            return typeof(AllEnums.MenuInicial);
        }
        else if(manager.IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            return typeof(AllEnums.Menumaterias);
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            return typeof(AllEnums.MenuEditarMaterias);
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            return typeof(AllEnums.Cadastro);
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Login)
        {
            return typeof(AllEnums.Login);
        }
        else
        {
            return typeof(AllEnums.Periodo);
        }
    }
    protected AllEnums.Teclas ReescritaParcial()
    {
        var tecla = TeclaPressionada();
        Console.CursorVisible = false;
        if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            AuxiliarReescritaParcial(typeof(AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            AuxiliarReescritaParcial(typeof(AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            AuxiliarReescritaParcial(typeof(AllEnums.MenuEditarMaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            AuxiliarReescritaParcial(typeof(AllEnums.Cadastro));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Login)
        {
            AuxiliarReescritaParcial(typeof(AllEnums.Login));
        }
        else
        {
            AuxiliarReescritaParcial(typeof(AllEnums.Periodo));
        }
        return tecla;
    }
    protected void AuxiliarReescritaParcial(Type typeEnum)
    {
        int posicaoAnterior = manager.Posicao;
        int indice = 0;
        int y = 1;
        foreach (KeyValuePair<string, string> item in helper.EnumCorrected(typeEnum))
        {
            if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro || manager.IniciarMenu == AllEnums.EscolherMenu.Login)
            {
                SubAuxiliarParcial(indice, item, y, posicaoAnterior, ':', typeEnum);
                indice++;
                y++;
            }
            else
            {
                SubAuxiliarParcial(indice, item, y, posicaoAnterior, '.', typeEnum);
                indice++;
                y++;
            }
        }
    }
    private void SubAuxiliarParcial(int indice, KeyValuePair<string, string> item, int y, int posicaoAnterior, char final, Type qualEnum)
    {
        if (qualEnum == typeof(AllEnums.Cadastro) || qualEnum == typeof(AllEnums.Login))
        {
            if (manager.Posicao == indice)
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
            else if(manager.Posicao == posicaoAnterior)
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
        }
        else
        {
            if (manager.Posicao == indice)
            {
                helper.Color(backColor: ConsoleColor.Green, letterColor: ConsoleColor.Red);
                helper.CursorPosition(2, y);
                Console.WriteLine($"> {item.Key}{final}");
                Console.ResetColor();
            }
            else if(manager.Posicao == posicaoAnterior)
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}{final}");
            }
        }
    }
    public void ApagarMenu()
    {
        if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            AuxiliarApagarMenu(typeof(AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            AuxiliarApagarMenu(typeof(AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            AuxiliarApagarMenu(typeof(AllEnums.MenuEditarMaterias));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            AuxiliarApagarMenu(typeof(AllEnums.Cadastro));
        }
        else if (manager.IniciarMenu == AllEnums.EscolherMenu.Login)
        {
            AuxiliarApagarMenu(typeof(AllEnums.Login));
        }
        else
        {
            AuxiliarApagarMenu(typeof(AllEnums.Periodo));
        }
    }
    public void AuxiliarApagarMenu(Type typeEnum)
    {
        if (typeEnum == typeof(AllEnums.Cadastro) || typeEnum == typeof(AllEnums.Login))
        {
            int y = 5;
            int x = 80;
            while (true)
            {
                helper.CursorPosition(x, y);
                Thread.Sleep(5);
                Console.Write(" ");
                if (x == 0)
                {
                    x = 80;
                    y--;
                }
                if (y < 0)
                {
                    break;
                }
                x--;
            }
        }
        else
        {
            int x = 40;
            int y = Enum.GetValues(typeEnum).Length + 1;
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
}