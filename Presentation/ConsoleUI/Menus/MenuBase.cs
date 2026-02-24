using System.Linq.Expressions;
using ArmazenamentoDeNotas.Presentation.Utils;
namespace ArmazenamentoDeNotas.Presentation.ConsoleUI.Menus;
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
        if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.MenuInicial));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuMaterias)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.Menumaterias));
        }
        else if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            EstruturaBase(typeof(Domain.Enums.AllEnums.MenuEditarMaterias));
        }
    }
    private void EstruturaBase(Type qualEnum)
    {
        helper.Color(backColor: ConsoleColor.Yellow, letterColor: ConsoleColor.White);
        Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
        for (int i = 0; i < Enum.GetValues(qualEnum).Length; i++)
        {
            Console.WriteLine("|" + "|".PadLeft(39));
        }
        Console.WriteLine(helper.RepeatChar(letter: '-', qtd: 40));
        Console.ResetColor();
    }
    private Domain.Enums.AllEnums.Teclas TeclaPressionada()
    {
        Domain.Enums.AllEnums.Teclas Tecla = Console.ReadKey(true).Key switch
        {
            ConsoleKey.UpArrow => Domain.Enums.AllEnums.Teclas.Subir,
            ConsoleKey.DownArrow => Domain.Enums.AllEnums.Teclas.Descer,
            ConsoleKey.Enter => Domain.Enums.AllEnums.Teclas.Enter,
            _ => Domain.Enums.AllEnums.Teclas.Nenhuma
        };
        return Tecla;
    }
    private void TratandoTecla(Domain.Enums.AllEnums.Teclas tecla)
    {
        if (manager.IniciarMenu == Domain.Enums.AllEnums.EscolherMenu.MenuInicial)
        {
            if (tecla == Domain.Enums.AllEnums.Teclas.Subir && manager.Posicao > 0)
            {
                manager.Posicao--;
            }
            else if (tecla == Domain.Enums.AllEnums.Teclas.Descer && manager.Posicao < Enum.GetValues(typeof(Domain.Enums.AllEnums.MenuInicial)).Length - 1)
            {
                manager.Posicao++;
            }
        }
    }
    /*protected Domain.Enums.AllEnums.Teclas ReescritaParcial()
    {
        int posicaoAnterior = manager.Posicao;
        var tecla = TeclaPressionada();
        foreach (KeyValuePair<string, string> item in helper.EnumCorrected(manager.IniciarMenu.GetType()))
        {
            
        }
    }*/
    protected void OpcaoSelecionada(int y, KeyValuePair<string, string> item)
    {
        helper.CursorPosition(2, y);
        helper.Color(ConsoleColor.Green, ConsoleColor.Red);
        Console.WriteLine($"> {item.Key}.");
        Console.ResetColor();
    }
    protected void OpcaoNaoSelecionada(int y, KeyValuePair<string, string> item)
    {
        helper.CursorPosition(2, y);
        Console.WriteLine($"  {item.Key}.");
        y++;
    }
}