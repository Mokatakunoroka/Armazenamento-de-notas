using ArmazenamentoDeNotas.Presentation.Utils;
namespace ArmazenamentoDeNotas.Presentation.ConsoleUI.Menus;
public class MenuInicial : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    public MenuInicial(Manager manager, Helper helper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
    }
    public void WritingOptions()
    {
        EscreverEstruturaCorreta();
        int y = 1;
        int indice = 0;
        foreach (KeyValuePair<string, string> item in helper.EnumCorrected(manager.IniciarMenu.GetType()))
        {
            if (manager.Posicao == indice)
            {
                OpcaoSelecionada(y, item);
            }
            else
            {
                OpcaoNaoSelecionada(y, item);
            }
            indice++;
        }
    }
}