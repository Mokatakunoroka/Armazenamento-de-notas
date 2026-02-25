using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var Manager = new Manager(new Helper());
        Manager.IniciarMenu = AllEnums.EscolherMenu.MenuMaterias;
        bool ativo = true;
        while (ativo)
        {
            Manager.ExecutarMenu(); //ARRUMAR A LÓGICA DO CADASTRO E LOGIN PQ O REESCRITA PARCIAL DO MENUBASE NÃO ESTÁ FUNCIONANDO.
                                    //DEIXANDO CLARO QUE A LÓGICA É ESCREVER PRIMEIRO DEPOIS SETAR A POSIÇÃO CORRETAMENTE E PEDIR CONSOLE.READLINE(); PARA ARMAZENAR
        }
    }
}