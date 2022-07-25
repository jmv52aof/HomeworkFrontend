using System.Data;
using System.Data.SqlClient;
using HomeworkWebApi.Models;

namespace HomeworkWebApi.Repositories;

public class RawSqlPatientRepository : IPatientRepository
{
    private readonly string _connectionString;

    public RawSqlPatientRepository( string connectionString )
    {
        _connectionString = connectionString;
    }

	public List<Patient> GetAll()
	{
		var result = new List<Patient>();
		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "select [Id], [Name], [Birthdate], [Phonenumber] from [Patient]";

		using SqlDataReader reader = sqlCommand.ExecuteReader();
		while ( reader.Read() )
		{
			result.Add( new Patient(
				Convert.ToInt32( reader[ "Id" ] ),
				Convert.ToString( reader[ "Name" ] ) ?? "",
				Convert.ToDateTime( reader[ "Birthdate" ] ),
				Convert.ToString( reader[ "Phonenumber" ] ) ?? ""
			) );
		}

		return result;
	}

	public Patient? GetById( int id )
	{
		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "select [Id], [Name], [Birthdate], [Phonenumber] from [Patient] where [Id] = @id";
		sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

		using SqlDataReader reader = sqlCommand.ExecuteReader();
		if ( reader.Read() )
		{
			return new Patient(
				Convert.ToInt32( reader[ "Id" ] ),
				Convert.ToString( reader[ "Name" ] ) ?? "",
				Convert.ToDateTime( reader[ "Birthdate" ] ),
				Convert.ToString( reader[ "Phonenumber" ] ) ?? ""
			);
		}
		else
		{
			return null;
		}
	}

	public void Delete( Patient patient )
	{
		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "delete from [Patient] where [Id] = @id";
		sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = patient.Id;

		sqlCommand.ExecuteNonQuery();
	}

	public void Update( Patient patient )
	{
		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "update [Patient] set [Name] = @name where [Id] = @id";
		sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = patient.Id;
		sqlCommand.Parameters.Add( "@name", SqlDbType.NVarChar, 255 ).Value = patient.Name;
		sqlCommand.ExecuteNonQuery();

		sqlCommand.CommandText = "update [Patient] set [Phonenumber] = @phoneNumber where [Id] = @id";
		sqlCommand.Parameters.Add( "@phoneNumber", SqlDbType.NVarChar, 255 ).Value = patient.PhoneNumber;
		sqlCommand.ExecuteNonQuery();
		
	}

	public void Add( string name, DateTime birthDate, string phoneNumber )
	{
		using var connection = new SqlConnection( _connectionString );
		connection.Open();

		using SqlCommand sqlCommand = connection.CreateCommand();
		sqlCommand.CommandText = "insert into [Patient] (Name, Birthdate, Phonenumber) values (@name, @birthdate, @phonenumber)";
		sqlCommand.Parameters.Add( "@name", SqlDbType.NVarChar, 255 ).Value = name;
		sqlCommand.Parameters.Add( "@birthdate", SqlDbType.DateTime ).Value = birthDate;
		sqlCommand.Parameters.Add( "@phonenumber", SqlDbType.NVarChar, 255 ).Value = phoneNumber;
		
		sqlCommand.ExecuteNonQuery();	
	}
}
