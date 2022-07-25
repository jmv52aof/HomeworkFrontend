using HomeworkWebApi.Models;

namespace HomeworkWebApi.Dto;

public static class PatientDtoExtension
{
    public static Patient ConvertToPatient( this PatientDto patientDto )
    {
        return new Patient(patientDto.Id, patientDto.Name ?? "", patientDto.BirthDate, patientDto.PhoneNumber ?? "");
    }

    public static PatientDto ConvertToPatientDto( this Patient patientDto )
    {
        return new PatientDto
        {
            Id = patientDto.Id,
            Name = patientDto.Name,
            BirthDate = patientDto.BirthDate,
            PhoneNumber = patientDto.PhoneNumber
        };
    }
}
