using System.Collections.Generic;
using MySqlConnector;

namespace ProjetoFullStack.Models
{
    public class ProdutosBanco
    {
         private const string dadosConexao = "Database=fullStack; Data Source= localhost; User Id= root";

        public void Inserir(Produtos produtos, int idUsuario)
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);
            Conexao.Open();
            string query = "insert into Produto(Nome, Valor, usuario) value(@Nome, @Valor, @Usuario)";
            MySqlCommand comando = new MySqlCommand(query,Conexao);
            comando.Parameters.AddWithValue("@Nome",produtos.Nome);
            comando.Parameters.AddWithValue("@Valor", produtos.Valor);
            comando.Parameters.AddWithValue("@Usuario", idUsuario);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<Produtos> BuscarTodos()
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "select Produto.*, Usuario.Nome as NomeUsuario from Produto left join Usuario on Produto.Usuario = Usuario.Id";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            MySqlDataReader reader = comando.ExecuteReader();
            List<Produtos> lista = new List<Produtos>();
                while(reader.Read())
                {
                    Produtos pr = new Produtos();
                    pr.Id = reader.GetInt32("Id");
                    if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                        pr.Nome = reader.GetString("Nome");
                    if(!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        pr.Valor = reader.GetDouble("Valor");
                    if(!reader.IsDBNull(reader.GetOrdinal("NomeUsuario")))
                        pr.Usuario = reader.GetString("NomeUsuario");
                    lista.Add(pr);
                }
                conexao.Close();
                return lista;
        }

        

    }
}