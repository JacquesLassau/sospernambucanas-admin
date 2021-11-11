﻿using System.Data.SqlClient;
using System.Data;
using System;
using DLLsSosPernambucanas.DML;

namespace DLLsSosPernambucanas.DAL
{    
    public class DaoToken: IDaoToken
    {
        public Conexao Conexao { get; set; }

        public DaoToken()
        {
            Conexao = new Conexao();
        }

        public void IncluirTokenDb(Token token)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarToken", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;
                                
                comandoDML.Parameters.Add("@Email", SqlDbType.VarChar, 200);                
                comandoDML.Parameters.Add("@UrlBase", SqlDbType.VarChar, 200);
                comandoDML.Parameters.Add("@StrToken", SqlDbType.VarChar, 200);
                
                comandoDML.Parameters["@Email"].Value = token.Email;
                comandoDML.Parameters["@UrlBase"].Value = token.UrlBase;
                comandoDML.Parameters["@StrToken"].Value = token.StrToken;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void GravarAcessoTokenDb(string token)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_GravarAcessoToken", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@StrToken", SqlDbType.VarChar, 200);
                comandoDML.Parameters["@StrToken"].Value = token;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public string BuscarEmailTokenDb(string token)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_BuscarEmailToken", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@StrToken", SqlDbType.VarChar, 200);
                comandoDML.Parameters["@StrToken"].Value = token;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool verificarEmailToken = dr.HasRows;                
                Usuario usuario = new Usuario();

                if (!verificarEmailToken)
                {
                    usuario.Email = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        string email = Convert.ToString(dr["EMAIL"]);                        
                        usuario = new Usuario(email);
                    }
                }

                conexao.Close();                
                return usuario.Email;
            }
        }

        public string BuscarValidadeTokenDb(string pToken)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_BuscarValidadeToken", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@StrToken", SqlDbType.VarChar, 200);
                comandoDML.Parameters["@StrToken"].Value = pToken;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool verificarEmailToken = dr.HasRows;
                Token token = new Token();

                if (!verificarEmailToken)
                {
                    token.StrToken = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        string strToken = Convert.ToString(dr["STrTOKEN"]);
                        token.StrToken = strToken;
                    }
                }

                conexao.Close();
                return token.StrToken;
            }
        }
    }
}
