using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
using Application.Service;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //Aceitar a saída de dados em UTF-8
        Console.InputEncoding = System.Text.Encoding.UTF8; //Aceitar a entrada de dados em UTF-8
        Console.Clear();
        /*var Manager = new Manager(new Helper());
        Manager.IniciarMenu = AllEnums.EscolherMenu.MenuInicial;
        bool ativo = true;
        while (ativo)
        {
            Manager.ExecutarMenu();
        }*/
        var Nota = new Nota(
                   new StringHelper(new Manager(new Helper()), new Helper()),
                   new Manager(new  Helper()), new Helper());
        Console.WriteLine(Nota.TransStringFloat("a"));
    }
}