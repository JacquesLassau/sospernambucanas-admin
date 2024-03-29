﻿using DLLsSosPernambucanas.DML;

namespace DLLsSosPernambucanas.DAL
{
    public interface IDALUsuario
    {
        void IncluirUsuarioDb(Usuario usuario);
        Usuario AcessoUsuarioDb(Usuario usuario);
        bool VerificarEmailUsuarioDb(int tipo, string email);
        void AlterarSenhaUsuarioDb(Usuario usuario);
    }
}
