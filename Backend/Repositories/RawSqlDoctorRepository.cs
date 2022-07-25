using System.Data;
using System.Data.SqlClient;
using HomeworkWebApi.Models;

namespace HomeworkWebApi.Repositories;

public class RawSqlDoctorRepository : IDoctorRepository
{
    private readonly string _connectionString;

    public RawSqlDoctorRepository( string connectionString )
    {
        _connectionString = connectionString;
    }

	public List<Doctor> GetAll()
	{
		var result = new List<Doctor>();

		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "select [Id], [Name], [Specialisation], [YearsOfExperience] from [Doctor]";

		using SqlDataReader reader = sqlCommand.ExecuteReader();
		while ( reader.Read() )
		{
			result.Add( new Doctor(
				Convert.ToInt32( reader[ "Id" ] ),
				Convert.ToString( reader[ "Name" ] ) ?? "",
				Convert.ToString( reader[ "Specialisation" ] ) ?? "",
				Convert.ToInt32( reader[ "YearsOfExperience" ] )
			) );
		}

		return result;
	}
}
