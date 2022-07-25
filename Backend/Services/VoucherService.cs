using HomeworkWebApi.Models;
using HomeworkWebApi.Dto;
using HomeworkWebApi.Repositories;

namespace HomeworkWebApi.Services;

public class VoucherService : IVoucherService
{
    private readonly IVoucherRepository _voucherRepository;

    public VoucherService( IVoucherRepository voucherRepository )
    {
        _voucherRepository = voucherRepository;
    }

    public List<Voucher> GetVouchers()
    {
        return _voucherRepository.GetAll();
    }

    public void Delete( int voucherId )
    {
        Voucher? voucher = _voucherRepository.GetById( voucherId );
        if ( voucher == null )
        {
            throw new Exception( $"{nameof( voucher )} not found, #Id - {voucherId}" );
        }
        _voucherRepository.Delete( voucher );
    }

    public void Add( DateTime receptionTime, int doctorId, int patientId )
    {
        _voucherRepository.Add( receptionTime, doctorId, patientId );
    }
}
