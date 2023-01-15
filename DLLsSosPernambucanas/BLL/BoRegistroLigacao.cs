using DLLsSosPernambucanas.DAL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;

namespace DLLsSosPernambucanas.BLL
{
    public class BoRegistroLigacao
    {
        /// <summary>
        /// Cadastra um novo registro de ligação.
        /// </summary>
        /// <param name="telDiscado"></param>
        /// <param name="emailUsuario"></param>
        /// <returns></returns>
        public bool CadastraRegistroLigacao(string telDiscado, string emailUsuario)
        {
            RegistroLigacao registro = new RegistroLigacao();
            registro.Numero = telDiscado;

            Usuario usuario = new Usuario();
            usuario.Email = emailUsuario;

            if (registro.Numero == Constantes.CENTRAL_ATENDIMENTO_MULHER)
                registro.Descricao = Constantes.CENTRAL_ATENDIMENTO_MULHER_DESCRICAO;
            else if (registro.Numero == Constantes.POLICIA)
                registro.Descricao = Constantes.POLICIA_DESCRICAO;

            DALRegistroLigacao dalRegistroLigacao = new DALRegistroLigacao();
            return dalRegistroLigacao.CadastraRegistroLigacaoDb(registro, usuario.Email);
        }
    }
}
