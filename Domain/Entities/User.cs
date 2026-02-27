using Domain.Enums;

namespace Domain.Enttities;
public class BancoDeUsuarios
{
    public List<Informacoes> Users {get; set;} = new List<Informacoes>();
}
public class Informacoes
{
    public string usuario { get; set; }
    public string senha {get; set;}
    public AllEnums.Periodo periodo {get; set;}
    public List<ListaMaterias> listaMaterias {get; set;} = new List<ListaMaterias>();
}
public class ListaMaterias
{
    public List<string> materias;
    public string nome;
    public float nota;
}
