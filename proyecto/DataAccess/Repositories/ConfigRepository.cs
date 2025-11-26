using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class ConfigRepository
    {
        private readonly string _connectionString = @"Server=localhost;Database=GestionProyecto;Trusted_Connection=True;TrustServerCertificate=True;";

        public SystemConfig GetConfig()
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT * FROM SystemConfig WHERE Id = 1", conn);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new SystemConfig
                {
                    MinPasswordLength = Convert.ToInt32(r["MinPasswordLength"]),
                    QuestionsToAnswer = Convert.ToInt32(r["QuestionsToAnswer"]),
                    RequireUpperLower = Convert.ToBoolean(r["RequireUpperLower"]),
                    RequireDigits = Convert.ToBoolean(r["RequireDigits"]),
                    RequireSpecial = Convert.ToBoolean(r["RequireSpecial"]),
                    Require2FA = Convert.ToBoolean(r["Require2FA"]),
                    DisallowPreviousPasswords = Convert.ToBoolean(r["DisallowPreviousPasswords"]),
                    DisallowPersonalData = Convert.ToBoolean(r["DisallowPersonalData"])
                };
            }
            return new SystemConfig();
        }

        public void SaveConfig(SystemConfig cfg)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(@"
                UPDATE SystemConfig SET
                  MinPasswordLength=@min,
                  QuestionsToAnswer=@q,
                  RequireUpperLower=@ul,
                  RequireDigits=@d,
                  RequireSpecial=@s,
                  Require2FA=@t,
                  DisallowPreviousPasswords=@dp,
                  DisallowPersonalData=@pp
                WHERE Id = 1", conn);
            cmd.Parameters.AddWithValue("@min", cfg.MinPasswordLength);
            cmd.Parameters.AddWithValue("@q", cfg.QuestionsToAnswer);
            cmd.Parameters.AddWithValue("@ul", cfg.RequireUpperLower);
            cmd.Parameters.AddWithValue("@d", cfg.RequireDigits);
            cmd.Parameters.AddWithValue("@s", cfg.RequireSpecial);
            cmd.Parameters.AddWithValue("@t", cfg.Require2FA);
            cmd.Parameters.AddWithValue("@dp", cfg.DisallowPreviousPasswords);
            cmd.Parameters.AddWithValue("@pp", cfg.DisallowPersonalData);
            cmd.ExecuteNonQuery();
        }
    }
}
