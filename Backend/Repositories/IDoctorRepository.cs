using HomeworkWebApi.Models;

namespace HomeworkWebApi.Repositories;

public interface IDoctorRepository
{
    List<Doctor> GetAll();
}
