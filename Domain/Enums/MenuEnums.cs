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
        Periodo,
        InfoAdicional
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
    public enum InfoAdicional
    {
        DigiteOPeriodoLetivo,
        DigiteAMédia
    }
    public enum MensagemErro
    {
        DigiteAlgoVálido
    }
    public enum Periodo
    {
        Bimestre = 4,
        Trimestre = 3,
        Semestre = 2
    }
    public enum Status
    {
        Reprovado,
        Aprovado
    }
}