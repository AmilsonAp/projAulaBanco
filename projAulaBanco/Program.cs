using System;
using System.Data.SqlClient;

namespace ProjAulaBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String Conexão 
            string strCon = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\Amilson\source\repos\ProjEventos\Banco\bdclient.mdf;";

            //Abre a conexão
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            Console.WriteLine("Conectou!");

            #region INSERIR TIPO
            //Exemplo Insert
            string strInsert = "insert into Tipo (Id, Descricao) values (@Id, @Descricao)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", 14));
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", "Sertanejo"));

            //Insere no Banco!
            commandInsert.ExecuteNonQuery();
            #endregion

            #region INSERIR APRESENTACAO
            //Exemplo Insert
            strInsert = "insert into Apresentacao (Id, Descricao, Duracao, Hora) values (@Id, @Descricao, @Duracao, @Hora)";
            commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", 8));
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", "Gustavo Lima"));
            commandInsert.Parameters.Add(new SqlParameter("@Duracao", 2));
            commandInsert.Parameters.Add(new SqlParameter("@Hora", 13));

            //Insere no Banco!
            commandInsert.ExecuteNonQuery();
            #endregion

            #region INSERIR ENDERECO
            //Exemplo Insert
            strInsert = "insert into Endereco (Id, Cep, Bairro, Logradouro, Numero, Complemento) values " +
                "(@Id, @Cep, @Bairro, @Logradouro, @Numero, @Complemento)";
            commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", 8));
            commandInsert.Parameters.Add(new SqlParameter("@Cep", 14813000));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", "Jardim Presidente"));
            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", "Rua Marechal Deodoro"));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", 46));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", "N/A"));

            //Insere no Banco!
            commandInsert.ExecuteNonQuery();
            #endregion

            #region CONSULTAR TIPO
            //Exemplo Consultar
            string strSelect = "select * from Tipo";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Id: " + dr["Id"] + "\nDescricao: " + dr["Descricao"]);
            }
            #endregion

            #region CONSULTAR APRESENTACAO
            //Exemplo Consultar
            conn.Close();
            conn.Open();
            strSelect = "select * from Apresentacao";
            commandSelect = new SqlCommand(strSelect, conn);
            dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Id: " + dr["Id"] + "\nDescricao: " + dr["Descricao"] + "\nDuracao: " + dr["Duracao"] + "\nHora: " + dr["Hora"]);
            }
            #endregion

            #region CONSULTAR ENDERECO
            //Exemplo Consultar
            conn.Close();
            conn.Open();
            strSelect = "select * from Endereco";
            commandSelect = new SqlCommand(strSelect, conn);
            dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Id: " + dr["Id"] + "\nCep: " + dr["Cep"] + "\nBairro: " + dr["Bairro"] + "\nLogradouro: " + 
                    dr["Logradouro"] + "\nNumero: " + dr["Numero"] + "\nComplemento: " + dr["Complemento"]);             
            }
            #endregion

            conn.Close();
            Console.WriteLine("Fim");
        }
    }
}