using HomeworkWebApi.Models;
using HomeworkWebApi.Dto;
using HomeworkWebApi.Repositories;

namespace HomeworkWebApi.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService( IDoctorRepository doctorRepository )
    {
        _doctorRepository = doctorRepository;
    }

    public List<Doctor> GetAll()
    {
        return _doctorRepository.GetAll();
    }
}
