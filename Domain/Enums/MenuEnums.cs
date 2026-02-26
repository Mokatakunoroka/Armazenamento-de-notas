namespace Domain.Enums;
public class AllEnums
{
    public enum EscolherMenu
    {
        MenuInicial,
        MenuEditarMaterias,
        MenuMaterias,
        Cadastro,
        Login,
        Periodo
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
    public enum Cadastro
    {
        DigiteSeuNomeParaOCadastro,
        DigiteSuaSenha
    }
    public enum Login
    {
        DigiteSeuNome,
        DigiteSuaSenha,
    }
    public enum MensagemErro
    {
        DigiteAlgoVálido
    }
    public enum Periodo
    {
        Bimestre,
        Trimestre,
        Semestre
    }
}