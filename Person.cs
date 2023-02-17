namespace ValidateJson;

public class Person
{
    protected Person()
    {
    }


    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Dni { get; set; }

    public bool comprova_dni()
    {
        if (Dni.Length != 9)
            return false;

        if (!int.TryParse(Dni.AsSpan(0, 8), out var dniNumber))
            return false;

        var expectedLetter = calcula_lletra(dniNumber);
        return expectedLetter == Dni[8];
    }

    public bool comprova_nom()
    {
        return !string.IsNullOrWhiteSpace(Name);
    }

    public bool comprova_mail()
    {
        if (string.IsNullOrWhiteSpace(Email))
            return false;

        if (!Email.Contains('@'))
            return false;

        return Email[0] != '@' && Email[^1] != '@';
    }

    private static char calcula_lletra(int dniNumber)
    {
        const string letters = "TRWAGMYFPDXBNJZSQVHLCKE";
        return letters[dniNumber % 23];
    }
}