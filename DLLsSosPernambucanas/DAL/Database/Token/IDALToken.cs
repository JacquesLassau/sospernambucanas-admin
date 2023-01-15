using DLLsSosPernambucanas.DML;

namespace DLLsSosPernambucanas.DAL
{
    public interface IDALToken
    {
        void IncluirTokenDb(Token token);
        void GravarAcessoTokenDb(string token);
        string BuscarEmailTokenDb(string token);
        string BuscarValidadeTokenDb(string pToken);
    }
}
