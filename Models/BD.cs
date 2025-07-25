using Microsoft.Data.SqlClient;
using Dapper;

namespace TP_SinNumero_Hevia_Ku.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost; DataBase=TP_SinNumero_Hevia-Ku;Integrated Security=True; TrustServerCertificate=True;";
    public static List<Integrante> MostrarIntegrantes() 
    {
        List<Integrante> integrantes = new List<Integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString)) 
        {
            string query = "SELECT * FROM Integrantes";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }
    public static Integrante encontrarUsuario(string email, string contrasenia)
    {
        Integrante integrante;
        using(SqlConnection connection = new SqlConnection(_connectionString)) 
        {
            string query = "SELECT email, password FROM Integrantes WHERE email = @Email AND password = @Contrasenia";
            integrante = connection.QueryFirstOrDefault<Integrante>(query, new { Email = email, Contrasenia = contrasenia });
        }
        return integrante;
    }
    public static Integrante encontrarUsuarioPorEmail(string email)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes WHERE email = @Email";
        return connection.QueryFirstOrDefault<Integrante>(query, new { Email = email });
    }
}

public static void AgregarUsuario(Integrante nuevo)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = @"INSERT INTO Integrantes 
            (nombreDeUsuario, email, password, fechaDeNacimiento, 
             palabrasClaveQueDescriban, logros, opinionProfesional, foto)
            VALUES 
            (@nombreDeUsuario, @email, @password, @fechaDeNacimiento, 
             @palabrasClaveQueDescriban, @logros, @opinionProfesional, @foto)";
        
        connection.Execute(query, nuevo);
    }
}

    
}