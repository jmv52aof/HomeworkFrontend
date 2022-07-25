using HomeworkWebApi.Repositories;
using HomeworkWebApi.Services;

var builder = WebApplication.CreateBuilder( args );

const string connectionString = @"Server=debian;Database=clinic;User Id=sa;Password=a12345678A;";

builder.Services.AddControllers();

builder.Services.AddScoped<IVoucherRepository>( s =>
    new RawSqlVoucherRepository( connectionString ) );
builder.Services.AddScoped<IVoucherService, VoucherService>();

builder.Services.AddScoped<IDoctorRepository>( s =>
    new RawSqlDoctorRepository( connectionString ) );
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IPatientRepository>( s =>
    new RawSqlPatientRepository( connectionString ) );
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();
app.MapControllers();
app.Run();
