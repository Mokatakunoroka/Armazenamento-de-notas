using Presentation.ConsoleUI;
using Domain.Enums;
using Presentation.Utils;
using Presentation.ConsoleUI.Menus;
using System.Linq.Expressions;
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
    public (string usuario, string senha, AllEnums.Periodo, List<string> materias) InputInfoUser()
    {
        EscrevendoEstrutura();
        Console.CursorVisible = true;
        string usuario = stringHelper.Input(37, 1);
        string senha = stringHelper.Input(22, 2);
        if (stringHelper.ValidarEntrada(usuario) || stringHelper.ValidarEntrada(senha) ||
            stringHelper.ValidarTamanho(usuario) || stringHelper.ValidarEntrada(senha))
        {
            helper.CursorPosition(0, 5);
            Console.WriteLine("Por favor digite um nome de usuário e senha válidos.");
            Console.ReadKey(true);
        }
        ApagarMenu();
        AllEnums.Periodo periodo = RetornaPeriodo();
        ApagarMenu();
        List<string> listaMaterias = RetornaListaMaterias();
        return (usuario, senha, periodo, listaMaterias);
    }
    public AllEnums.Periodo RetornaPeriodo()
    {
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
            else
            {
                AllEnums.Periodo periodo = AllEnums.Periodo.Semestre;
                return periodo;
            }
        }
    }
    private List<string> RetornaListaMaterias()
    {
        List<string> listaMaterias = new List<string>();
        while (true)
        {
            string materia = stringHelper.Input("Digite o nome de uma matéria: ");
            listaMaterias.Add(materia);
            string escolha = stringHelper.Input("Deseja adicionar alguma outra materia (s/n)? \n");
            if (escolha[0] == 's')
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return listaMaterias;
    }
}