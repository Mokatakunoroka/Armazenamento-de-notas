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
            return false;
        }
        return true;
    }
    public bool ValidarEntrada(string entrada)
    {
        if (string.IsNullOrWhiteSpace(entrada))
        {
            return false;
        }
        return true;
    }
    public string Capitalizar(string mensagem)
    {
        string mensagemFormatada = mensagem.Trim().ToLower();
        string[] mensagemSeparada = mensagemFormatada.Split();
        List<string> resultadoTemporario = new List<string>();
        HashSet<string> naoAlterar = new()
        {
            "de", "a", "e", "ao", "ou", "o", "da"
        };
        foreach (string elemento in mensagemSeparada)
        {
            if (string.IsNullOrWhiteSpace(elemento))
            {
                continue;
            }
            else if (naoAlterar.Contains(elemento))
            {
                resultadoTemporario.Add(elemento);
            }
            else
            {
                resultadoTemporario.Add(char.ToUpper(elemento[0]) + elemento.Substring(1));
            }
        }
        return string.Join(" ", resultadoTemporario);
    }
}