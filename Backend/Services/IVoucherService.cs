using HomeworkWebApi.Models;

namespace HomeworkWebApi.Services;

public interface IVoucherService
{
    List<Voucher> GetVouchers();
    void Delete ( int voucherId );
    void Add( DateTime receptionTime, int doctorId, int patientId );
}
