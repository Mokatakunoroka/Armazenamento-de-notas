using Infrastructure.Persistence;
using Presentation.Utils;
namespace Presentation.ConsoleUI.Menus;
public class MenuMaterias : MenuBase
{
    private readonly Helper helper;
    private readonly Manager manager;
    private readonly JsonRepository json;
    public MenuMaterias(Manager manager, Helper helper, JsonRepository json) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
        this.json = json;
    }
    public void Redirecionar()
    {
        EscrevendoEstrutura();
        Domain.Enums.AllEnums.Teclas tecla = ReescritaParcial();
        if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.VerMaterias)
        {
            helper.ApagarMenu(manager.IniciarMenu);
        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.AdicionarMaterias)
        {
            helper.ApagarMenu(manager.IniciarMenu);
            //ADICIONAR A FUNÇÃO DE ADICIONAR MATÉRIAS
            //json.AdicionarMaterias();
            //Preciso saber o usuário que está logado.

        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.EditarMaterias)
        {
            helper.ApagarMenu(manager.IniciarMenu);
            manager.QtdInstanciadaMenus = 0;
            manager.Posicao = 0;
            manager.IniciarMenu = Domain.Enums.AllEnums.EscolherMenu.MenuEditarMaterias;
        }
        else if (tecla == Domain.Enums.AllEnums.Teclas.Enter && manager.Posicao == (int)Domain.Enums.AllEnums.Menumaterias.Sair)
        {
            helper.CursorPosition(0, Enum.GetValues(typeof(Domain.Enums.AllEnums.Menumaterias)).Length + 3);
            Environment.Exit(0);
        }
    }
}