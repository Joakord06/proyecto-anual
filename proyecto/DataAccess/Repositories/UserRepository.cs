using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DataAccess.Entities;
using System;
using System.Collections.Generic;


namespace DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString = @"Server=localhost;Database=GestionProyecto;Trusted_Connection=True;";

        public User GetUserById(int id)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Username, Password, SecurityAnswer FROM Users WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        SecurityAnswer = reader["SecurityAnswer"].ToString()
                    };
                }
            }
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Username, Password, SecurityAnswer FROM Users WHERE Username=@username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        SecurityAnswer = reader["SecurityAnswer"].ToString()
                    };
                }
            }
            return user;
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (Username, Password, SecurityAnswer) VALUES (@username, @password, @securityAnswer)", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@securityAnswer", user.SecurityAnswer ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUserPassword(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Password=@password WHERE Username=@username", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Username, Password, SecurityAnswer FROM Users", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        SecurityAnswer = reader["SecurityAnswer"].ToString()
                    });
                }
            }
            return users;
        }
    }
}
