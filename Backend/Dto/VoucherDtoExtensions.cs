using HomeworkWebApi.Models;

namespace HomeworkWebApi.Dto;

public static class VoucherDtoExtensions
{
    public static Voucher ConvertToVoucher( this VoucherDto voucherDto )
    {
        return new Voucher(voucherDto.Id, voucherDto.ReceptionTime, voucherDto.DoctorId, voucherDto.PatientId);
    }

    public static VoucherDto ConvertToVoucherDto( this Voucher voucherDto )
    {
        return new VoucherDto
        {
            Id = voucherDto.Id,
            ReceptionTime = voucherDto.ReceptionTime,
            DoctorId = voucherDto.DoctorId,
            PatientId = voucherDto.PatientId
        };
    }
}
