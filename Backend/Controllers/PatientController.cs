using Microsoft.AspNetCore.Mvc;
using HomeworkWebApi.Dto;
using HomeworkWebApi.Services;

namespace HomeworkWebApi.Controllers;

[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController( IPatientService patientService )
    {
        _patientService = patientService;
    }

    [HttpGet("patient")]
    public IActionResult GetPatients()
    {
        try
        {
            return Ok( _patientService.GetAll()
                .ConvertAll( t => t.ConvertToPatientDto() ) );
        }
        catch ( Exception ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "patient/delete/{patientId}" )]
    public IActionResult DeletePatient( int patientId )
    {
        try
        { 
            _patientService.DeleteById( patientId );
            return Ok( );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "patient/update/name/{patientId}/{name}" )]
    public IActionResult UpdateName( int patientId, string name )
    {
        try
        { 
            _patientService.UpdateNameById( patientId, name );
            return Ok( );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "patient/update/phonenumber/{patientId}/{phoneNumber}" )]
    public IActionResult UpdatePhonenumber( int patientId, string phoneNumber )
    {
        try
        { 
            _patientService.UpdatePhonenumberById( patientId, phoneNumber );
            return Ok( );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "patient/add/{name}/{birthDate}/{phoneNumber}" )]
    public IActionResult AddPatient( string name, DateTime birthDate, string phoneNumber)
    {
        try
        { 
            _patientService.AddPatient( name, birthDate, phoneNumber );
            return Ok( );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }
}
