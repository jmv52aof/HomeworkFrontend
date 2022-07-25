namespace HomeworkWebApi.Dto;

public class VoucherDto
{
    public int Id { get; set; }
    public DateTime ReceptionTime { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
}
