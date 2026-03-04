using Presentation.ConsoleUI;
using Presentation.Utils;
using Domain.Enums;
using System.Collections.Generic;

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
                string matéria = sHelper.Input("Digite o nome da matéria que será adicionada: ");
            }
            catch
            {
                
            }
        }
    }
    public void PeriodoCorreto()
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
            else if (manager.UsuarioLogado.periodo == AllEnums.Periodo.Trimestre)
            {
                
            }

        }
        catch (ArgumentException ex)
        {
            helper.TratarErro(ex);
        }

    }
}