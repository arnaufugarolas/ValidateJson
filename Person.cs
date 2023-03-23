namespace ValidateJson;

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Dni { get; set; }

    public bool CheckDni()
    {
        if (string.IsNullOrWhiteSpace(Dni))
            return false;

        var dni = Dni.ToUpper();
        try
        {
            var dniNumber = int.Parse(dni[..^1]);
            var dniLetter = dni[^1];
            return dniLetter == CalculateLetter(dniNumber);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool CheckName()
    {
        return !string.IsNullOrWhiteSpace(Name);
    }

    public bool CheckMail()
    {
        if (string.IsNullOrWhiteSpace(Email))
            return false;

        if (!Email.Contains('@'))
            return false;

        return Email[0] != '@' && Email[^1] != '@';
    }

    private static char CalculateLetter(int dniNumber)
    {
        const string letters = "TRWAGMYFPDXBNJZSQVHLCKE";
        return letters[dniNumber % 23];
    }
}