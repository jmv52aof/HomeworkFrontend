using HomeworkWebApi.Models;

namespace HomeworkWebApi.Repositories;

public interface IPatientRepository
{
    public List<Patient> GetAll();
    public Patient? GetById( int id );
    public void Delete( Patient patient );
    public void Update( Patient patient );
    public void Add(string name, DateTime birthDate, string phoneNumber);
}
