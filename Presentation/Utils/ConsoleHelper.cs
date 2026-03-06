using Domain.Enums;
using Presentation.ConsoleUI;
namespace Presentation.Utils;
public class Helper
{
    public void Color(ConsoleColor backColor, ConsoleColor letterColor)
    {
        Console.BackgroundColor = backColor;
        Console.ForegroundColor = letterColor;
    }
    public string RepeatChar(char letter, int qtd)
    {
        string result = "";
        for (int i = 0; i < qtd; i++)
        {
            result += letter;
        }
        return result;
    }
    public void CursorPosition(int x, int y) => Console.SetCursorPosition(x, y);
    public Dictionary<string, string> EnumCorrected(Type typeEnum)
    {
        var tempList = new List<char>();
        var resultDict = new Dictionary<string,string>();
        int count = 0;
        foreach (string memberEnum in Enum.GetNames(typeEnum))
        {
            foreach (char letter in memberEnum)
            {
                if (char.IsUpper(letter) && count == 0)
                {
                    tempList.Add(letter);
                }
                else if (char.IsUpper(letter))
                {
                    tempList.Add(' ');
                    tempList.Add(char.ToLower(letter));
                }
                else
                {
                    tempList.Add(letter);
                }
                count++;
            }
            resultDict.Add(string.Join("", tempList), memberEnum);
            tempList.Clear();
            count = 0;
        }
        return resultDict;
    }
    public string MensagemErro(AllEnums.MensagemErro mensagemErro)
    {
        string resultado = "";
        int contador = 0;
        foreach (char letra in mensagemErro.ToString())
        {
            if (char.IsUpper(letra) && contador == 0)
            {
                resultado += letra;
            }
            else if (char.IsUpper(letra))
            {
                resultado += ' ';
                resultado += letra;
            }
            else
            {
                resultado += letra;
            }
            contador++;
        }
        return resultado;
    }
    public AllEnums.MensagemErro VoltarMensagemErroParaEnum(string mensagemErro)
    {
        string resultado = "";
        int contador = 0;
        foreach (char letra in mensagemErro)
        {
            if (char.IsUpper(letra) && contador == 0 )
            {
                resultado += letra;
            }
            else if (!char.IsWhiteSpace(letra))
            {
                resultado += letra;
            }
        }
        if (Enum.TryParse(resultado, out AllEnums.MensagemErro valor)) 
        {
            return valor;
        }
        else
        {
            throw new ArgumentException("Não foi possível voltar para o enum");
        }
    }
    public void ApagarMenu(AllEnums.EscolherMenu MenuInicializado)
    {
        if (MenuInicializado == AllEnums.EscolherMenu.MenuInicial)
        {
            AuxiliarApagarMenu(typeof(AllEnums.MenuInicial));
        }
        else if (MenuInicializado == AllEnums.EscolherMenu.MenuMaterias)
        {
            AuxiliarApagarMenu(typeof(AllEnums.Menumaterias));
        }
        else if (MenuInicializado == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            AuxiliarApagarMenu(typeof(AllEnums.MenuEditarMaterias));
        }
        else if (MenuInicializado == AllEnums.EscolherMenu.Cadastro)
        {
            AuxiliarApagarMenu(typeof(AllEnums.Cadastro));
        }
        else if (MenuInicializado == AllEnums.EscolherMenu.Login)
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
            int y = Enum.GetValues(typeEnum).Length + 1;;
            int x = 80;
            while (true)
            {
                CursorPosition(x, y);
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
                CursorPosition(x, y);
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
    public void ApagarLinha(int xInicial, int xFinal, int y)
    {
        while (true)
        {
            CursorPosition(xFinal, y);
            Console.Write(" ");
            xFinal--;
            if (xFinal == xInicial - 1)
            {
                break;
            }
        }
    }
    public void TratarErro(ArgumentException ex)
    {
        CursorPosition(0, 5);
        Console.WriteLine(ex);
        ApagarLinha(0, 180, 6);
        Console.ReadKey(true);
        CursorPosition(0, 0);
    }
}