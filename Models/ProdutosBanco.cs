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
            string query = "insert into Produto(Nome, Valor,Quantidade, usuario) value(@Nome,@Quantidade, @Valor, @Usuario)";
            MySqlCommand comando = new MySqlCommand(query,Conexao);
            comando.Parameters.AddWithValue("@Nome",produtos.Nome);
            comando.Parameters.AddWithValue("@Quantidade",produtos.Quantidade);
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
                     if(!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        pr.Quantidade = reader.GetInt32("Quantidade");
                    if(!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        pr.Valor = reader.GetDouble("Valor");
                    if(!reader.IsDBNull(reader.GetOrdinal("NomeUsuario")))
                        pr.Usuario = reader.GetString("NomeUsuario");
                    lista.Add(pr);
                }
                conexao.Close();
                return lista;
        }

        public void Atualizar(Produtos produtos)
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "update Produto set Nome = @Nome, Quantidade = @Quantidade, Valor = @Valor  where Id = @Id" ;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@Nome",produtos.Nome);
            comando.Parameters.AddWithValue("@Quantidade",produtos.Quantidade);
            comando.Parameters.AddWithValue("@Valor",produtos.Valor);
            comando.Parameters.AddWithValue("@Id",produtos.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    
        public void Remover(int Id)
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "delete from Produto where Id = @Id";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        
        public Produtos ConsultaPorId(int Id)
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "select * from Produto  where Id= @Id";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@Id",Id);
            MySqlDataReader reader = comando.ExecuteReader();
            Produtos pr = null;
            if(reader.Read())
            {
                pr = new Produtos();
                pr.Id = reader.GetInt32("Id");
                
                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    pr.Nome = reader.GetString("Nome");
                 if(!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                    pr.Quantidade = reader.GetInt32("Quantidade");
                if(!reader.IsDBNull(reader.GetOrdinal("Valor")))
                    pr.Valor = reader.GetDouble("Valor");
               
            }
            conexao.Close();
            return pr;
        }

        

    }
}