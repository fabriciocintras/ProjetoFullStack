using System.Collections.Generic;
using MySqlConnector;

namespace ProjetoFullStack.Models
{
    public class UsuarioBanco
    {
        private const string dadosConexao = "Database=fullStack; Data Source= localhost; User Id= root";

        public void Inserir(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(dadosConexao);
            Conexao.Open();
            string query = "insert into usuario(Nome,Login,Senha,Tipo) value(@Nome,@Login,@Senha,@Tipo)";
            MySqlCommand comando = new MySqlCommand(query,Conexao);
            comando.Parameters.AddWithValue("@Nome",usuario.Nome);
            comando.Parameters.AddWithValue("@Login", usuario.Login);
            comando.Parameters.AddWithValue("@Senha",usuario.Senha);
            comando.Parameters.AddWithValue("@Tipo",usuario.Tipo);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<Usuario> Query()
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "select * from usuario order by Nome";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            MySqlDataReader reader = comando.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
                while(reader.Read())
                {
                    Usuario us = new Usuario();
                    us.Id = reader.GetInt32("Id");
                     us.Tipo = reader.GetInt32("Tipo");

                    if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                        us.Nome = reader.GetString("Nome");
                    if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                        us.Login = reader.GetString("Login");
                    if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                        us.Senha = reader.GetString("Senha");
                        lista.Add(us);
                }
                conexao.Close();
                return lista;
        }

        public Usuario QueryLogin(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();
            string sql = "select * from usuario where Login = @Login and Senha = @Senha";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@Login",u.Login);
            comando.Parameters.AddWithValue("@Senha",u.Senha);
            MySqlDataReader reader = comando.ExecuteReader();
            Usuario us = null;
                if(reader.Read())
                {
                    us = new Usuario();
                    us.Id = reader.GetInt32("Id");
                    us.Tipo = reader.GetInt32("Tipo");
                    
                    if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                        us.Nome = reader.GetString("Nome");
                    if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                        us.Login = reader.GetString("Login");
                    if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                        us.Senha = reader.GetString("Senha");
                    
                }
                conexao.Close();
                return us;
        }

    

        

    }
}