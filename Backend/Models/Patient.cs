namespace HomeworkWebApi.Models;

public class Patient
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string? PhoneNumber { get; private set; }
    public Patient( int id, string name, DateTime birthDate, string phoneNumber )
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }

    public void UpdateName( string newName )
    {
        Name = newName;
    }

    public void UpdateBirthDate( DateTime birthDate )
    {
        BirthDate = birthDate;
    }
    public void UpdatePhoneNumber( string phoneNumber )
    {
        PhoneNumber = phoneNumber;
    }
}
