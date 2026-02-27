using Application.Service;
using Domain.Enums;
using Infrastructure.Persistence;
using Presentation.ConsoleUI.Menus;
using Presentation.Utils;
namespace Presentation.ConsoleUI;
public class Manager
{
    public AllEnums.EscolherMenu IniciarMenu { get; set; }
    private Helper helper;
    public Manager(Helper helper)
    {
        this.helper = helper;
    }
    public int Posicao;
    public int QtdInstanciadaMenus;
    public void ExecutarMenu()
    {
        if (IniciarMenu == AllEnums.EscolherMenu.MenuInicial)
        {
            var MenuInicial = new MenuInicial(this, helper);
            MenuInicial.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuMaterias)
        {
            var MenuMaterias = new MenuMaterias(this, helper);
            MenuMaterias.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.MenuEditarMaterias)
        {
            var MenuEditarMaterias = new MenuEditarMaterias(this, helper);
            MenuEditarMaterias.Redirecionar();
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.Cadastro)
        {
            var stringHelper = new StringHelper(this, helper);
            var Cadastro = new Cadastro(this, helper, stringHelper);
            var (usuario, senha, periodo) = Cadastro.InputInfoUser();
            var JsonRepository = new JsonRepository();
            JsonRepository.SalvarUsuario(usuario, senha, periodo);
            IniciarMenu = AllEnums.EscolherMenu.MenuMaterias;
            QtdInstanciadaMenus = 0;
        }
        else if (IniciarMenu == AllEnums.EscolherMenu.Login)
        {
            //Login
        }
        else
        {
            //Periodo
        }
    }
}