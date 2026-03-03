using Presentation.ConsoleUI;
using System.Text.Json;
using Presentation.Utils;
using Domain.Enttities;
using Presentation.ConsoleUI.Menus;
namespace Application.Service;
public class Login : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    private readonly StringHelper stringHelper;
    public Login(Helper helper, Manager manager, StringHelper stringHelper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
        this.stringHelper = stringHelper;
    }
    public (string usuario, string senha)? InputLogin()
    {
        if (File.Exists("dados.json"))
        {
            EscrevendoEstrutura();
            string usuario = "";
            string senha = "";
            while (true)
            {
                Console.CursorVisible = true;
                usuario = stringHelper.Input(21, 1);
                senha = stringHelper.Input(22, 2); 
                if (stringHelper.ValidarEntrada(usuario) && stringHelper.ValidarEntrada(senha) &&
                    stringHelper.ValidarTamanho(usuario) && stringHelper.ValidarTamanho(senha))
                {
                    break;
                }
                else
                {
                    helper.CursorPosition(0, 5);
                    Console.CursorVisible = false;
                    Console.WriteLine("Por favor digite um nome de usuário e senha válidos.");
                    helper.ApagarLinha(21, 40, 1);
                    helper.ApagarLinha(22, 40, 2);
                    Console.ReadKey(true);
                    helper.CursorPosition(21, 1);
                }
            }
            helper.ApagarMenu(manager.IniciarMenu);
            Console.CursorVisible = true;
            return (usuario, senha);
        }
        else
        {
            helper.CursorPosition(0, 0);
            Console.WriteLine("Cadastre primeiro!");
            Console.ReadKey(true);
            helper.ApagarLinha(0, 20, 0);
            manager.QtdInstanciadaMenus = 0;
            manager.Posicao = 0;
            manager.IniciarMenu = Domain.Enums.AllEnums.EscolherMenu.MenuInicial;
            return null;
        }
    }
    public bool Logar(string usuario, string senha)
    {
        string jsonLido = File.ReadAllText("dados.json");
        try
        {
            BancoDeUsuarios? banco = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonLido);
            if (banco == null || banco.Users == null)
            {
                return false;
            }
            foreach (Informacoes conteudo in banco.Users)
            {
                if (conteudo.usuario == usuario && conteudo.senha == senha)
                {
                    manager.UsuarioLogado = conteudo;
                    return true;
                }
            }
            return false;
        }
        catch
        {
            helper.ApagarMenu(manager.IniciarMenu);
            helper.CursorPosition(0,0);
            Console.WriteLine("dados.json está corrompido ou inválido.");
            return false;
        }
    }
}