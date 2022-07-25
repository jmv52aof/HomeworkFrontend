using HomeworkWebApi.Models;
using HomeworkWebApi.Dto;

namespace HomeworkWebApi.Services;

public interface IDoctorService
{
    List<Doctor> GetAll();
}
