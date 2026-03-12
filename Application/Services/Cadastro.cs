using Presentation.ConsoleUI;
using Domain.Enums;
using Presentation.Utils;
using Presentation.ConsoleUI.Menus;
using Infrastructure.Persistence;
using System.Data.Common;
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
    public void InputInfoUser()
    {
        string usuario = "";
        string senha = "";
        EscrevendoEstrutura();
        while (true)
        {
            try
            {
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
                    helper.ApagarLinha(37, 40, 1);
                    helper.ApagarLinha(22, 40, 2);
                    throw new ArgumentException("Nome ou senha inválida.");
                }
            }
            catch (ArgumentException ex)
            {
                helper.TratarErro(ex);
            }
            finally
            {
                helper.ApagarMenu(manager.IniciarMenu);
                AllEnums.Periodo periodo = RetornaPeriodo();
                helper.ApagarMenu(manager.IniciarMenu);
                JsonRepository json = new JsonRepository(helper, manager);
                json.SalvarUsuario(usuario, senha, periodo);
                SalvarUsuarioLogado(usuario);
            }
        }
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