using Microsoft.AspNetCore.Mvc;
using HomeworkWebApi.Services;
using HomeworkWebApi.Dto;

namespace HomeworkWebApi.Controllers;

[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController( IDoctorService doctorService )
    {
        _doctorService = doctorService;
    }

    [HttpGet("doctor")]
    public IActionResult GetAll()
    {
        try
        {
            return Ok( _doctorService.GetAll()
                .ConvertAll( t => t.ConvertToDoctorDto() ) );
        }
        catch ( Exception ex )
        {
            return BadRequest( ex.Message );
        }
    }
}
