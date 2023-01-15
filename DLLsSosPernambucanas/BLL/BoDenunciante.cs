using DLLsSosPernambucanas.DAL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System.Collections.Generic;
using System;

namespace DLLsSosPernambucanas.BLL
{
    public class BoDenunciante
    {
        DALDenunciante _dalDenunciante;
        public BoDenunciante()
        {
            _dalDenunciante = new DALDenunciante();
        }
        /// <summary>
        /// Cadastra um novo denunciante.
        /// </summary>
        /// <param name="denunciante"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public Denunciante IncluirDenunciante(Denunciante denunciante)
        {
            denunciante.Situacao = Convert.ToInt32(Constantes.SituacaoUsuario.ATIVO);
            denunciante.Tipo = Convert.ToInt32(Constantes.TipoUsuario.DENUNCIANTE);

            BoUsuario boUsuario = new BoUsuario();            

            if (!boUsuario.VerificarEmailUsuario(denunciante.Tipo, denunciante.Email))                            
                return _dalDenunciante.IncluirDenuncianteDb(denunciante);                            
            else            
                return null;                       
        }

        /// <summary>
        /// Edita um denunciante.
        /// </summary>
        /// <param name="denunciante"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public string EditarDenunciante(Denunciante denunciante)
        {            
            string result = _dalDenunciante.EditarDenuncianteDb(denunciante);

            if (string.IsNullOrEmpty(result))
                return Constantes.ALTERACAO_DENUNCIANTE_SUCESSO;
            else
                return result;
        }

        /// <summary>
        /// Exclui logicamente um denunciante.
        /// </summary>
        /// <param name="denunciante"></param>
        /// <returns>Cadeia de caracteres contendo log da ação.</returns>
        public string ExcluirDenunciante(Denunciante denunciante)
        {
            denunciante.Situacao = Convert.ToInt32(Constantes.SituacaoUsuario.INATIVO);
            string result = _dalDenunciante.ExcluirDenuncianteDb(denunciante);

            if (result == null)
                return Constantes.EXCLUSAO_DENUNCIANTE_SUCESSO;
            else
                return result;
        }

        /// <summary>
        /// Lista de denunciantes da base de dados.
        /// </summary>
        /// <param></param>
        /// <returns>Propriedade do tipo List<Denunciante></returns>
        public List<Denunciante> ListaDenunciantes()
        {            
            return _dalDenunciante.ListarDenunciantesDb();
        }

        /// <summary>
        /// Seleciona um denunciante da base de dados.
        /// </summary>
        /// <param name="idDenunciante"></param>
        /// <returns>Propriedade do tipo Denunciante</returns>
        public Denunciante SelecionaDenunciante(int idDenunciante)
        {            
            return _dalDenunciante.SelecionarDenuncianteDb(idDenunciante);
        }
    }
}

