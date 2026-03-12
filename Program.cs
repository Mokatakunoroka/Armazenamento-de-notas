using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
using Application.Service;
using Domain.Enttities;
using System.Text.Json;
class Program 
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //Aceitar a saída de dados em UTF-8
        Console.InputEncoding = System.Text.Encoding.UTF8; //Aceitar a entrada de dados em UTF-8
        Console.Clear();
        var Manager = new Manager(new Helper());
        string jsonlido = File.ReadAllText("dados.json");
        BancoDeUsuarios banco = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonlido)!;
        foreach (var conteudo in banco.Users)
        {
            if (conteudo.periodo == AllEnums.Periodo.Trimestre)
            {
                Manager.UsuarioLogado = conteudo;
                break;
            }
        }
        Manager.IniciarMenu = AllEnums.EscolherMenu.InfoAdicional;
        bool ativo = true;
        while (ativo)
        {
            Manager.ExecutarMenu();
        }
    }
}