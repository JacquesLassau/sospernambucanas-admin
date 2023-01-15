using DLLsSosPernambucanas.DAL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System;
using System.Collections.Generic;

namespace DLLsSosPernambucanas.BLL
{
    public class BoAtendente
    {
        DALAtendente _dalAtendente;

        public BoAtendente()
        {
            _dalAtendente = new DALAtendente();
        }

        /// <summary>
        /// Cadastra um novo atendente.
        /// </summary>
        /// <param name="atendente"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public string IncluirAtendente(Atendente atendente)
        {
            atendente.Situacao = Convert.ToInt32(Constantes.SituacaoUsuario.ATIVO);
            atendente.Tipo = Convert.ToInt32(Constantes.TipoUsuario.ATENDENTE);
                        
            string result = _dalAtendente.IncluirAtendenteDb(atendente);

            if (result == null)
                return Constantes.CADASTRO_ATENDENTE_SUCESSO;
            else
                return result;
        }

        /// <summary>
        /// Editar um atendente.
        /// </summary>
        /// <param name="atendente"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public string EditarAtendente(Atendente atendente)
        {            
            string result = _dalAtendente.EditarAtendenteDb(atendente);

            if (result == null)
                return Constantes.ALTERACAO_ATENDENTE_SUCESSO;
            else
                return result;
        }

        /// <summary>
        /// Editar um atendente.
        /// </summary>
        /// <param name="atendente"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public string ExcluirAtendente(Atendente atendente)
        {
            atendente.Situacao = Convert.ToInt32(Constantes.SituacaoUsuario.INATIVO);            
                        
            string result = _dalAtendente.ExcluirAtendenteDb(atendente);

            if (result == null)
                return Constantes.EXCLUSAO_ATENDENTE_SUCESSO;
            else
                return result;
        }

        /// <summary>
        /// Lista de atendentes da base de dados.
        /// </summary>
        /// <param></param>
        /// <returns>Propriedade do tipo List<Atendente></returns>
        public List<Atendente> ListaAtendentes()
        {            
            return _dalAtendente.ListarAtendentesDb();
        }

        /// <summary>
        /// Seleciona um atendente da base de dados.
        /// </summary>
        /// <param name="idAtendente"></param>
        /// <returns>Propriedade do tipo Atendente</returns>
        public Atendente SelecionaAtendente(int idAtendente)
        {            
            return _dalAtendente.SelecionarAtendenteDb(idAtendente);
        }
    }
}
