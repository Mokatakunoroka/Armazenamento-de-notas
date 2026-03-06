using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
using System.Collections.Generic;
using System.Globalization;

namespace Application.Service;
public class Nota
{
    private StringHelper sHelper;
    private Manager manager;
    private Helper helper;
    public Nota(StringHelper sHelper, Manager manager, Helper helper)
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
    /*public Dictionary<float, AllEnums.Status> PeriodoCorreto(string materia)
    {
        try
        {
            if (manager.UsuarioLogado == null)
            {
                throw new ArgumentException("Usuario logado ainda não foi setado.");
            }
            if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Bimestre)
            {
                
            }
            else if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Trimestre)
            {
                
            }
            else if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Semestre)
            {
                
            }

        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
        }
    }*/
    public float? TransStringFloat(string transformar)
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
    public int QtdDigitos(float numero)
    {
        int temp = numero.ToString(CultureInfo.InvariantCulture).Split(".").Count();
        if (temp > 1)
        {
            string[] resultado = numero.ToString(CultureInfo.InvariantCulture).Split(".");
            return Math.Abs(string.Join("", resultado).Replace("-", "").Length);
        }
        return Math.Abs(numero.ToString(CultureInfo.InvariantCulture).Length);
    }
    public float FloatSemVirgula(float numero)
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