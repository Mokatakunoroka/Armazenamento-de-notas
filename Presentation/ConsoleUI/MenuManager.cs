using ArmazenamentoDeNotas.Domain.Enums;
namespace ArmazenamentoDeNotas.Presentation.ConsoleUI;
public class Manager
{
    private AllEnums.EscolherMenu _escolherMenu;
    public AllEnums.EscolherMenu IniciarMenu
    {
        get => _escolherMenu;
        set => _escolherMenu = value;
    }
    public int Posicao;
}