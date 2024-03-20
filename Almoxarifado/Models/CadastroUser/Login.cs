using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Models.CadastroUser
{
    public class Login
    {
        private readonly static string _conn = @"Data Source=DESKTOP-2MLSNHE\SQLEXPRESS;Initial Catalog=DB_ALMOXARIFADO; Integrated Security=True;";

        public string LoginName { get; set; }
        public string PasswordLogin { get; set; }

        public bool Authenticate()
        {
            var result = false;
            var sql = "SELECT ID_LOGIN, LOGIN_NAME, PASSWORD_LOGIN FROM TB_AD_LOGIN WHERE LOGIN_NAME = @LoginName";

            try
            {
                using (var cn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@LoginName", LoginName);
                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Verifica se a senha fornecida corresponde à senha armazenada no banco de dados
                            if (PasswordLogin == dr["PASSWORD_LOGIN"].ToString())
                            {
                                // Autenticação bem-sucedida
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções (log, etc.)
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
