using HomeworkWebApi.Models;
using HomeworkWebApi.Dto;
using HomeworkWebApi.Repositories;

namespace HomeworkWebApi.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService( IPatientRepository patientRepository )
    {
        _patientRepository = patientRepository;
    }

    public List<Patient> GetAll()
    {
        return _patientRepository.GetAll();
    }

    public void UpdateNameById( int id, string name )
    {
        Patient? patient = _patientRepository.GetById( id );
        if ( patient != null )
        {
            patient.UpdateName( name );
            _patientRepository.Update( patient );
        }
    }

    public void UpdatePhonenumberById( int id, string phoneNumber )
    {
        Patient? patient = _patientRepository.GetById( id );
        if ( patient != null )
        {
            patient.UpdatePhoneNumber( phoneNumber );
            _patientRepository.Update( patient );
        }
    }

    public void DeleteById( int id )
    {
        Patient? patient = _patientRepository.GetById( id );
        if ( patient != null )
        {
            _patientRepository.Delete( patient );
        }
    }

    public void AddPatient( string name, DateTime birthDate, string phoneNumber )
    {
        _patientRepository.Add( name, birthDate, phoneNumber );
    }
}
