using System.Collections.Generic;
using DLLsSosPernambucanas.DML;

namespace DLLsSosPernambucanas.DAL
{
    internal interface IDALAtendente
    {
        string IncluirAtendenteDb(Atendente atendente);
        Atendente SelecionarAtendenteDb(int idAtendente);        
        string EditarAtendenteDb(Atendente atendente);
        List<Atendente> ListarAtendentesDb();
        string ExcluirAtendenteDb(Atendente atendente);
    }
}
