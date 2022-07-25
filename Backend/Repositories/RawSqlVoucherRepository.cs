﻿using System.Data;
using System.Data.SqlClient;
using HomeworkWebApi.Models;

namespace HomeworkWebApi.Repositories
{
    public class RawSqlVoucherRepository : IVoucherRepository
    {
        private readonly string _connectionString;

        public RawSqlVoucherRepository( string connectionString )
        {
            _connectionString = connectionString;
        }

        public List<Voucher> GetAll()
        {
            var result = new List<Voucher>();

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [ReceptionTime], [DoctorId], [PatientId] from [Voucher]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                result.Add( new Voucher(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToDateTime( reader[ "ReceptionTime" ] ),
                    Convert.ToInt32( reader[ "DoctorId" ] ),
                    Convert.ToInt32( reader[ "PatientId" ] )
                ) );
            }

            return result;
        }

        public Voucher? GetById( int id )
        {
            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [ReceptionTime], [DoctorId], [PatientId] from [Voucher] where [Id] = @id";
            sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if ( reader.Read() )
            {
                return new Voucher(
                    Convert.ToInt32( reader[ "Id" ] ),
                    Convert.ToDateTime( reader[ "ReceptionTime" ] ),
                    Convert.ToInt32( reader[ "DoctorId" ] ),
                    Convert.ToInt32( reader[ "PatientId" ] )
                );
            }
            else
            {
                return null;
            }
        }

        public void Delete( Voucher voucher )
        {
            if ( voucher == null )
            {
                throw new ArgumentNullException( nameof( voucher ) );
            }

            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Voucher] where [Id] = @id";
            sqlCommand.Parameters.Add( "@id", SqlDbType.Int ).Value = voucher.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public void Add( DateTime receptionTime, int doctorId, int patientId )
        {
            using var connection = new SqlConnection( _connectionString );
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Voucher] (ReceptionTime, DoctorId, PatientId) values (@receptionTime, @doctorId, @patientId)";
            sqlCommand.Parameters.Add( "@receptionTime", SqlDbType.DateTime ).Value = receptionTime;
            sqlCommand.Parameters.Add( "@doctorId", SqlDbType.Int ).Value = doctorId;
            sqlCommand.Parameters.Add( "@patientId", SqlDbType.Int ).Value = patientId;
            
            sqlCommand.ExecuteNonQuery();	
        }
    }
}
