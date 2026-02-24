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
        if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuMaterias)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.MenuEditarMaterias));
        }
    }
    private void EstruturaBase(Type qualEnum)
    {
        helper.Color(backColor: ConsoleColor.Black, letterColor: ConsoleColor.Yellow);
        helper.CursorPosition(0, 0);
        Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
        for (int i = 0; i < Enum.GetValues(qualEnum).Length; i++)
        {
            Console.WriteLine("|" + "|".PadLeft(39));
        }
        Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
        Console.ResetColor();
    }
    public void EscrevendoEstrutura()
    {
        if (manager.QtdInstanciadaMenus == 0)
        {
            manager.QtdInstanciadaMenus++;
            EscreverEstruturaCorreta();
            if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
            {
                AuxiliarEscreverOpcoes(typeof(Domain.Enums.AllEnums.MenuInicial));
            }
            else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuMaterias)
            {
                AuxiliarEscreverOpcoes(typeof(Domain.Enums.AllEnums.Menumaterias));
            }
            else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias)
            {
                AuxiliarEscreverOpcoes(typeof(Domain.Enums.AllEnums.MenuEditarMaterias));
            }
        }
    }
    private void AuxiliarEscreverOpcoes(Type typeEnum)
    {
        int y = 1;
        int indice = 0;
        foreach (KeyValuePair<string, string> item in helper.EnumCorrected(typeEnum))
        {
            if (manager.Posicao == indice) //opção selecionada
            {
                helper.CursorPosition(2, y);
                helper.Color(ConsoleColor.Green, ConsoleColor.Red);
                Console.WriteLine($"> {item.Key}.");
                Console.ResetColor();
            }
            else // Opção não selecionada
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}.");
            }
            y++;
            indice++;
        }
    }
    protected Domain.Enums.AllEnums.Teclas TeclaPressionada()
    {
        Domain.Enums.AllEnums.Teclas Tecla = Console.ReadKey(true).Key switch
        {
            ConsoleKey.UpArrow => Domain.Enums.AllEnums.Teclas.Subir,
            ConsoleKey.DownArrow => Domain.Enums.AllEnums.Teclas.Descer,
            ConsoleKey.Enter => Domain.Enums.AllEnums.Teclas.Enter,
            _ => Domain.Enums.AllEnums.Teclas.Nenhuma
        };
        //Preciso verificar o numero da poição atual e fazer alterações no thi.posição
        if (Tecla == Domain.Enums.AllEnums.Teclas.Subir && manager.Posicao> 0)
        {
            manager.Posicao--;
        }
        else if (Tecla == Domain.Enums.AllEnums.Teclas.Descer && manager.Posicao < Enum.GetValues(AuxiliarTecla(manager.IniciarMenu.GetType())).Length - 1)
        {
            manager.Posicao++;
        }
        return Tecla;
    }
    private Type AuxiliarTecla(Type qualEnum)
    {
        if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
        {
            return typeof(Domain.Enums.AllEnums.MenuInicial);
        }
        else if(manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuMaterias)
        {
            return typeof(Domain.Enums.AllEnums.Menumaterias);
        }
        else
        {
            return typeof(Domain.Enums.AllEnums.MenuEditarMaterias);
        }
    }
    protected Domain.Enums.AllEnums.Teclas ReescritaParcial()
    {
        var tecla = TeclaPressionada();
        Console.CursorVisible = false;
        if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
        {
            AuxiliarReescritaParcial(typeof(Domain.Enums.AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuMaterias)
        {
            AuxiliarReescritaParcial(typeof(Domain.Enums.AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            AuxiliarReescritaParcial(typeof(Domain.Enums.AllEnums.MenuEditarMaterias));
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
            if (manager.Posicao == indice)
            {
                helper.Color(backColor: ConsoleColor.Green, letterColor: ConsoleColor.Red);
                helper.CursorPosition(2, y);
                Console.WriteLine($"> {item.Key}.");
                Console.ResetColor();
            }
            else if(manager.Posicao == posicaoAnterior)
            {
                helper.CursorPosition(2, y);
                Console.WriteLine($"  {item.Key}.");
            }
            indice++;
            y++;
        }
    }
}