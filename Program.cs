using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //Aceitar a saída de dados em UTF-8
        Console.InputEncoding = System.Text.Encoding.UTF8; //Aceitar a entrada de dados em UTF-8
        Console.Clear();
        var Manager = new Manager(new Helper());
        Manager.IniciarMenu = AllEnums.EscolherMenu.MenuInicial;
        bool ativo = true;
        while (ativo)
        {
            Manager.ExecutarMenu();
        }
    }
}