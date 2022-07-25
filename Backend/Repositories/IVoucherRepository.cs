using HomeworkWebApi.Models;
namespace HomeworkWebApi.Repositories;

public interface IVoucherRepository
{
    List<Voucher> GetAll();
    Voucher? GetById( int id );
    void Delete( Voucher voucher );
    void Add( DateTime receptionTime, int doctorId, int patientId );
}
