using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var Manager = new Manager(new Helper());
        Manager.IniciarMenu = AllEnums.EscolherMenu.MenuInicial;
        bool ativo = true;
        while (ativo)
        {
            Manager.ExecutarMenu(); //O JSON CADASTRO ESTÁ SOBRESCREVENDO O OUTRO.
        }
    }
}