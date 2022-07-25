using HomeworkWebApi.Models;

namespace HomeworkWebApi.Dto;

public static class DoctorDtoExtension
{
    public static Doctor ConvertToDoctor( this DoctorDto doctorDto )
    {
        return new Doctor(doctorDto.Id, doctorDto.Name ?? "", doctorDto.Specialisation ?? "", doctorDto.YearsOfExperience);
    }

    public static DoctorDto ConvertToDoctorDto( this Doctor doctorDto )
    {
        return new DoctorDto
        {
            Id = doctorDto.Id,
            Name = doctorDto.Name,
            Specialisation = doctorDto.Specialisation,
            YearsOfExperience = doctorDto.YearsOfExperiene
        };
    }
}
