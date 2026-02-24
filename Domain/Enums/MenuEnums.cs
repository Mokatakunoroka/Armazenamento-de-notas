namespace Domain.Enums;
public class AllEnums
{
    public enum EscolherMenu
    {
        MenuInicial,
        MenuEditarMaterias,
        MenuMaterias
    }
    public enum MenuInicial
    {
        Cadastro,
        Login,
        Sair
    }
    public enum MenuEditarMaterias
    {   AlterarNome,
        AlterarNota,
        ExcluirMaterias,
        AlterarPeríodo,
        Voltar
    }
    public enum Menumaterias
    {
        VerMaterias,
        AdicionarMaterias,
        EditarMaterias,
        Sair
    }
    public enum Teclas
    {
        Subir,
        Descer,
        Enter,
        Nenhuma
    }
}