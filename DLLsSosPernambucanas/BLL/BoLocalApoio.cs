using DLLsSosPernambucanas.DAL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System.Collections.Generic;

namespace DLLsSosPernambucanas.BLL
{
    public class BoLocalApoio
    {
        DALLocalApoio _daoLocal;

        public BoLocalApoio()
        {
            _daoLocal = new DALLocalApoio();
        }
        /// <summary>
        /// Lista com locais de apoio na base de dados.
        /// </summary>
        /// <param></param>
        /// <returns>Propriedade do tipo List<LocalApoio></returns>
        public List<LocalApoio> ListaLocaisApoio()
        {            
            return _daoLocal.ListarLocaisApoioDb();
        }

        /// <summary>
        /// Lista com locais de apoio na base de dados.
        /// </summary>
        /// <param></param>
        /// <returns>Propriedade do tipo List<Denunciante></returns>
        public string IncluirLocalApoio(LocalApoio localApoio)
        {
            string result = _daoLocal.IncluirLocarApoioDb(localApoio);

            if (result == null)
                return Constantes.CADASTRO_LOCAL_APOIO_SUCESSO;
            else
                return result;            
        }

        /// <summary>
        /// Lista com locais de apoio na base de dados.
        /// </summary>
        /// <param></param>
        /// <returns>Propriedade do tipo List<Denunciante></returns>
        public string ExcluirLocalApoio(int idLocal)
        {
            string result = _daoLocal.ExcluirLocarApoioDb(idLocal);

            if (result == null)
                return Constantes.EXCLUSAO_LOCAL_APOIO_SUCESSO;
            else
                return result;

        }
    }
}
