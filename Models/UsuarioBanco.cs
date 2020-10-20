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
            string query = "insert into usuario(Nome,Login,Senha) value(@Nome,@Login,@Senha)";
            MySqlCommand comando = new MySqlCommand(query,Conexao);

            comando.Parameters.AddWithValue("@Nome",usuario.Nome);
            comando.Parameters.AddWithValue("@Login", usuario.Login);
            comando.Parameters.AddWithValue("@Senha",usuario.Senha);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        

    }
}