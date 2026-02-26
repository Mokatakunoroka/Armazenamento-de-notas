using Presentation.ConsoleUI;
using Domain.Enums;
namespace Presentation.Utils;
public class StringHelper
{
    private Manager manager;
    private Helper helper;
    public StringHelper(Manager manager, Helper helper)
    {
        this.manager = manager;
        this.helper = helper;
    }
    public string Input(int x, int y)
    {
        helper.CursorPosition(x, y);
        string input = Console.ReadLine() ?? helper.MensagemErro(AllEnums.MensagemErro.DigiteAlgoVálido);
        return input;
    }
    public string Input(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine() ?? "";
    }
    public bool ValidarTamanho(string entrada)
    {
        if (entrada.Length < 3)
        {
            return true;
        }
        return false;
    }
    public bool ValidarEntrada(string entrada)
    {
        if (string.IsNullOrWhiteSpace(entrada))
        {
            return true;
        }
        return false;
    }

}