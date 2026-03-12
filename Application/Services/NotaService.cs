using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
using System.Collections.Generic;
using System.Globalization;
using Presentation.ConsoleUI.Menus;
using System.Net.Security;
using System.Data.SqlTypes;

namespace Application.Service;
public class Nota : MenuBase
{
    private StringHelper sHelper;
    private Manager manager;
    private Helper helper;
    public Nota(StringHelper sHelper, Manager manager, Helper helper) :base(manager, helper)
    {
        this.sHelper = sHelper;
        this.manager = manager;
        this.helper = helper;
    }
    public KeyValuePair<string, Dictionary<float, AllEnums.Status>>? PedirMaterias()
    {
        while (true)
        {
            try
            {
                string materia = sHelper.Input("Digite o nome da matéria que será adicionada: ");
            }
            catch
            {
                
            }
        }
    }
    private (int periodoLetivo, int media) InformacoesLetivas(AllEnums.Periodo periodo)
    {
        EscrevendoEstrutura();
        while (true)
        {
            try
            {
                string periodoLetivo = sHelper.Input(29, 1).Replace("°", "");
                string media = sHelper.Input(20, 2).Replace("°", "");
                if (int.TryParse(periodoLetivo.Trim(), out int valorLetivo) && //Estou verificando se peridoLetivo e media podem ser transformados em int
                    int.TryParse(media.Trim(), out int valorMedia))
                {
                    if (valorLetivo < 0 || valorLetivo > Enum.GetValues(periodo.GetType()).Length)
                    {
                        switch (periodo)
                        {
                            case AllEnums.Periodo.Bimestre: 
                                throw new ArgumentException($"O valor letivo precisa ser entre o 1° bimestre e o 4° e não {valorLetivo}.");
                            case AllEnums.Periodo.Trimestre:
                                throw new ArgumentException($"O valor letivo precisa ser entre 1° trimestre e 3° e não {valorLetivo}.");
                            case AllEnums.Periodo.Semestre:
                                throw new ArgumentException($"O valor letivo precisa ser entre 1° semestre e o 2° e não {valorLetivo}.");
                            default:
                                throw new ArgumentException($"Membro do enum 'AllEnums.Periodo.{periodo},' inválido.");
                        };
                    }
                    else if (valorMedia < 6 || valorMedia > 7)
                    {
                        throw new ArgumentException("O valor digitado da média da sua instituição tem que ser entre 6 e 7.");
                    }
                    return (valorLetivo, valorMedia);
                }
                else
                {
                    throw new ArgumentException("Por favor, digite apenas números válidos.");
                }
            }
            catch (ArgumentException ex)
            {
                helper.TratarErro(ex);
                ApagarLinha(29, 79, 1);
                ApagarLinha(20, 79, 2);
            }
        }
    }
    public Dictionary<float, AllEnums.Status> PeriodoCorreto(string materia)
    {
        try
        {
            if (manager.UsuarioLogado == null)
            {
                throw new ArgumentException("Não existe usuário logado.");
            }
            if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Bimestre)
            {
                /*
                Para caso o usuário não tenha nenhuma matéria adicionada
                ele pede o período e a média, a qual será a base para todo o calculo da nota restante.
                */
                if (manager.UsuarioLogado.listaMaterias.Count() == 0)
                {
                    var item = InformacoesLetivas(AllEnums.Periodo.Bimestre);
                }
            }
            else if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Trimestre)
            {
                // Seria interessante saber qual trimestre o usuário está, para depois calcular corretamente.
            }
            else if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Semestre)
            {
                // Seria interessante saber qual semestre o usuário está, para depois calcular corretamente.
            }

        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
        }
    }
    private int NotaCorreta(int media, int peridoLetivo, AllEnums.Periodo qualPeriodo)
    {
        int comecoLetivo = 1;
        EstruturaBase(70, 1);
        while (true)
        {
            string nota = sHelper.Input($"Digite a sua nota do {sHelper.AlterarCor($"{comecoLetivo}°", ConsoleColor.DarkMagenta)} {qualPeriodo}: ");
            float? notaFormatada = FormatarNota(nota);
            if (comecoLetivo < peridoLetivo && notaFormatada != null)
            {
                comecoLetivo++;
            }

        }
    }
    private float? FormatarNota(string transformar)
    {
        //Transformar sempre para número float em duas casas
        try
        {
         if (float.TryParse(transformar.Trim(), out float valor))
            {
                if (valor > 100 ||  valor < 0 || FloatSemVirgula(valor) / 10 > 10)
                {
                    throw new ArgumentException("Valor Inválido");
                }
                else if (QtdDigitos(valor) == 2 && FloatSemVirgula(valor) > 1)
                {
                    return FloatSemVirgula(valor) / 10;
                }
                else if (valor == 100)
                {
                    return valor / 10;
                }
                else
                {
                    return valor;
                }
            }   
            else
            {
            throw new ArgumentException("Não foi possível converter a string para float.");
            }
        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
            return null;
        }
    }
    private int QtdDigitos(float numero)
    {
        int temp = numero.ToString(CultureInfo.InvariantCulture).Split(".").Count();
        if (temp > 1)
        {
            string[] resultado = numero.ToString(CultureInfo.InvariantCulture).Split(".");
            return Math.Abs(string.Join("", resultado).Replace("-", "").Length);
        }
        return Math.Abs(numero.ToString(CultureInfo.InvariantCulture).Length);
    }
    private float FloatSemVirgula(float numero)
    {
        if (numero < 1)
        {
            return Math.Abs(numero);
        }
        string resultado = string.Join("", numero.ToString(CultureInfo.InvariantCulture).Split("."));
        bool conversao = int.TryParse(resultado, out int valor);
        return Math.Abs(valor);
    }
}