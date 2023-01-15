using DLLsSosPernambucanas.DML;

namespace DLLsSosPernambucanas.DAL
{
    public interface IDALRegistroLigacao
    {
        bool CadastraRegistroLigacaoDb(RegistroLigacao registroLigacao, string emailUsuario);        
    }
}
