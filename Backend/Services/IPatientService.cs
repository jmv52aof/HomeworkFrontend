using HomeworkWebApi.Models;

namespace HomeworkWebApi.Services;

public interface IPatientService
{
    public List<Patient> GetAll();
    public void UpdateNameById( int id, string name );
    public void UpdatePhonenumberById( int id, string phoneNumber );
    public void DeleteById( int id );
    public void AddPatient( string name, DateTime birthDate, string phoneNumber );
}
