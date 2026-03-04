using System.Text.Json;
using Domain.Enttities;
using Presentation.ConsoleUI;
using Presentation.ConsoleUI.Menus;
using Presentation.Utils;

namespace Infrastructure.Persistence;
public class JsonFileHelper : Helper
{
    private Helper helper;
    private Manager manager;
    public JsonFileHelper(Manager manager, Helper helper)
    {
        this.manager = manager;
        this.helper = helper;
    }
    public void SalvarUsuarioLogado(string usuario)
    {
        try
        {
            bool naoEncontrouUsuario = false;
            string jsonlido = File.ReadAllText("dados.json");
            BancoDeUsuarios banco = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonlido)!; 
            if (banco == null || banco.Users == null)
            {
                throw new ArgumentException("Banco inválido.");
            }
            foreach (Informacoes conteudo in banco.Users)
            {
                if (conteudo.usuario == usuario)
                {
                    naoEncontrouUsuario = true;
                    manager.UsuarioLogado = conteudo;
                    break;
                }
            }
            if (!naoEncontrouUsuario)
            {
                throw new ArgumentException("Usuário não encontrado");
            }
        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
            manager.MudarMenu(Domain.Enums.AllEnums.EscolherMenu.MenuInicial);
        }
    }
}