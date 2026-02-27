using Presentation.ConsoleUI;
using Domain.Enums;
using Presentation.Utils;
using Presentation.ConsoleUI.Menus;
namespace Application.Service;
public class Cadastro : MenuBase
{

    private Manager manager;
    private Helper helper;
    private StringHelper stringHelper;
    public Cadastro(Manager manager,Helper helper, StringHelper stringHelper) : base(manager, helper)
    {
        this.helper = helper;
        this.manager = manager;
        this.stringHelper = stringHelper;
    }
    public (string usuario, string senha, AllEnums.Periodo) InputInfoUser()
    {
        string usuario = "";
        string senha = "";
        while (true)
        {
            EscrevendoEstrutura();
            Console.CursorVisible = true;
            usuario = stringHelper.Input(37, 1);
            senha = stringHelper.Input(22, 2);
            if (stringHelper.ValidarEntrada(usuario) && stringHelper.ValidarEntrada(senha) &&
                stringHelper.ValidarTamanho(usuario) && stringHelper.ValidarTamanho(senha))
            {
                break;
            }
            else
            {
                helper.CursorPosition(0, 5);
                Console.WriteLine("Por favor digite um nome de usuário e senha válidos.");
                Console.CursorVisible = false;
                ApagarLinha(37, 40, 1);
                ApagarLinha(22, 40, 2);
                Console.ReadKey(true);
                helper.CursorPosition(37, 1);
            }
        }
        ApagarMenu();
        AllEnums.Periodo periodo = RetornaPeriodo();
        ApagarMenu();
        return (usuario, senha, periodo);
    }
    public AllEnums.Periodo RetornaPeriodo()
    {
        manager.IniciarMenu = AllEnums.EscolherMenu.Periodo;
        manager.QtdInstanciadaMenus = 0;
        EscrevendoEstrutura();
        while (true)
        {
            var tecla = ReescritaParcial();
            if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.Periodo.Bimestre)
            {
                AllEnums.Periodo periodo = AllEnums.Periodo.Bimestre;
                return periodo;
            }
            else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.Periodo.Trimestre)
            {
                AllEnums.Periodo periodo = AllEnums.Periodo.Trimestre;
                return periodo;
            }
            else if (tecla == AllEnums.Teclas.Enter && manager.Posicao == (int)AllEnums.Periodo.Semestre)
            {
                AllEnums.Periodo periodo = AllEnums.Periodo.Semestre;
                return periodo;
            }
        }
    }
}