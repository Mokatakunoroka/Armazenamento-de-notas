using Domain.Enttities;
using Domain.Enums;
using Presentation.ConsoleUI;
using Presentation.Utils;
using System.Text.Json;
namespace Infrastructure.Persistence;
public class JsonRepository : JsonFileHelper
{
    private Helper helper;
    public JsonRepository(Helper helper)
    {
        this.helper = helper;
    }
    public void SalvarUsuario(string usuario, string senha, AllEnums.Periodo periodo)
    {
        if (File.Exists("dados.json"))
        {
            string jsonLido = File.ReadAllText("dados.json"); //Lendo o arquivo
            BancoDeUsuarios json = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonLido)!; //Transformando o que foi lido em objeto
            Informacoes novasInformacoes = new Informacoes() //Adicionando as novas informações
            {
                usuario = usuario,
                senha = senha,
                periodo = periodo
            };
            json.Users.Add(novasInformacoes); //adicionando as informações ao objeto
            string jsonString = JsonSerializer.Serialize(json, new JsonSerializerOptions {WriteIndented = true}); //transformando objeto em string
            File.WriteAllText("dados.json", jsonString); //escrevendo novamente no arquivo
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
    public void AdicionarMaterias(string usuario, KeyValuePair<string, float> materia)
    {
        if (File.Exists("dados.json"))
        {
            string jsonLido = File.ReadAllText("dados.json");
            BancoDeUsuarios? banco = JsonSerializer.Deserialize<BancoDeUsuarios>(jsonLido);
            if (banco == null || banco.Users == null)
            {
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Banco nulo.");
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
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Usuario não encontrado.");
                    helper.ApagarLinha(0, 20, 8);
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
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Não existe nenhum arquivo.");
        }
    }
}