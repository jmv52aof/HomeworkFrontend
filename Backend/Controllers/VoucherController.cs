using Microsoft.AspNetCore.Mvc;
using HomeworkWebApi.Dto;
using HomeworkWebApi.Services;

namespace HomeworkWebApi.Controllers;

[ApiController]
public class VoucherController : ControllerBase
{
    private readonly IVoucherService _voucherService;

    public VoucherController( IVoucherService voucherService )
    {
        _voucherService = voucherService;
    }

    [HttpGet("voucher")]
    public IActionResult GetVouchers()
    {
        try
        {
            return Ok( _voucherService.GetVouchers()
                .ConvertAll( t => t.ConvertToVoucherDto() ) );
        }
        catch ( Exception ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "voucher/delete/{voucherId}" )]
    public IActionResult DeleteVoucher( int voucherId )
    {
        try
        { 
            _voucherService.Delete( voucherId );
            return Ok( $"Removed voucher, ID: {voucherId}" );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    [Route( "voucher/add/{receptionTime}/{doctorId}/{patientId}" )]
    public IActionResult AddVoucher( DateTime receptionTime, int doctorId, int patientId )
    {
        try
        { 
            _voucherService.Add( receptionTime, doctorId, patientId );
            return Ok( );
        }
        catch (Exception ex)
        {
            return BadRequest( ex.Message );
        }
    }
}
