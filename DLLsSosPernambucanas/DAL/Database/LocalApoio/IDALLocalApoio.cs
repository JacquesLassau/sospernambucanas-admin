using DLLsSosPernambucanas.DML;
using System.Collections.Generic;

namespace DLLsSosPernambucanas.DAL
{
    public interface IDALLocalApoio
    {
        List<LocalApoio> ListarLocaisApoioDb();
        string IncluirLocarApoioDb(LocalApoio localApoio);
        string ExcluirLocarApoioDb(int idLocal);
    }
}
