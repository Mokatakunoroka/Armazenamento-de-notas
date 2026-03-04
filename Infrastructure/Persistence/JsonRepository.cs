using Domain.Enttities;
using Domain.Enums;
using Presentation.ConsoleUI;
using Presentation.Utils;
using System.Text.Json;
namespace Infrastructure.Persistence;
public class JsonRepository : JsonFileHelper
{
    private Helper helper;
    private Manager manager;
    public JsonRepository(Helper helper, Manager manager) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void SalvarUsuario(string usuario, string senha, AllEnums.Periodo periodo)
    {
        try
        {
            if (File.Exists("dados.json"))
            {
                string jsonLido = File.ReadAllText("dados.json"); //Lendo o arquivo
                BancoDeUsuarios json = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonLido)!;//Transformando o que foi lido em objeto
                if (json == null || json.Users == null)
                {
                    throw new ArgumentException("Banco inválido");
                }
                Informacoes novasInformacoes = new Informacoes() //Adicionando as novas informações
                {
                    usuario = usuario,
                    senha = senha,
                    periodo = periodo
                };
                json.Users.Add(novasInformacoes); //adicionando as informações ao objeto
                string jsonString = JsonSerializer.Serialize(json, new JsonSerializerOptions {WriteIndented = true}); //transformando objeto em string
                File.WriteAllText("dados.json", jsonString); //escrevendo no arquivo
            }
            else
            {
                BancoDeUsuarios bancoDeUsuarios = new BancoDeUsuarios();
                Informacoes informacoes = new Informacoes()
                {
                    usuario = usuario,
                    senha = senha,
                    periodo = periodo,
                };
                bancoDeUsuarios.Users.Add(informacoes);
                string json = JsonSerializer.Serialize(bancoDeUsuarios, new JsonSerializerOptions(){ WriteIndented = true}); //transformando o objeto em string
                File.WriteAllText("dados.json", json); // escrevendo no arquivo
            }
        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
        }
    }
    public void AdicionarMaterias(string usuario, KeyValuePair<string, float> materia)
    {
        try
        {
            if (File.Exists("dados.json"))
            {
                string jsonLido = File.ReadAllText("dados.json");
                BancoDeUsuarios? banco = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonLido);
                if (banco == null || banco.Users == null)
                {
                    throw new ArgumentException("Banco nulo");
                }
                else
                {
                    bool encontrouUsuario = false;
                    foreach (Informacoes conteudo in banco.Users)
                    {
                        if (conteudo.usuario == usuario)
                        {
                            ListaMaterias lista = new ListaMaterias()
                            {
                                nome = materia.Key,
                                nota = materia.Value
                            };
                            conteudo.listaMaterias.Add(lista);
                            encontrouUsuario = true;
                            break;
                        }
                    }
                    if (!encontrouUsuario)
                    {
                        throw new ArgumentException("Usuário não encontrado.");
                    }
                    else
                    {
                        string json = JsonSerializer.Serialize(banco, new JsonSerializerOptions() {WriteIndented = true});
                        File.WriteAllText("dados.json", json);
                    }
                }
            }
            else
            {
                throw new ArgumentException("O arquivo não existe.");
            }
        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
        }
    }
}