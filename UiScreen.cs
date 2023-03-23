using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;

namespace ValidateJson;

public partial class UiScreen : Form
{
    private static List<Person> _persons;
    private static List<Person> _filtredPersons;
    private bool _canPocessData;

    public UiScreen()
    {
        InitializeComponent();
    }

    private void GetDataFromJson()
    {
        _persons = new List<Person>();
        var dialog = new OpenFileDialog();
        dialog.Filter = @"Archivos json (*.json)|*.json|Archivos de texto (*.txt)|*.txt";
        if (DialogResult.OK != dialog.ShowDialog())
            return;

        Task.Run(() => LoadJsonData(dialog));

        dialog.Dispose();
    }

    private void SetData(IEnumerable<Person> persons)
    {
        dgrid_datos.Rows.Clear();
        dgrid_datos.DataSource = null;
        foreach (var person in persons)
            try
            {
                dgrid_datos.Rows.Add(
                    person.Name,
                    person.Surname,
                    person.Gender,
                    person.Company,
                    person.Email,
                    person.Country,
                    person.Dni
                );
            }
            catch (Exception)
            {
                // ignored
            }
    }


    private Task LoadJsonData(FileDialog dialog)
    {
        tb_pathFile.Text = dialog.FileName;
        if (!File.Exists(dialog.FileName))
            return Task.CompletedTask;

        var json = File.ReadAllText(dialog.FileName);
        _persons = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            SetData(_persons);
            label_total_personas.Text = _persons.Count.ToString();
            label_num_validas.Text = @"?/" + _persons.Count;
            label_num_invalidas.Text = @"?/" + _persons.Count;
            _canPocessData = true;
        });


        return Task.CompletedTask;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cb_modoUso.SelectedItem = "SEQUENCIAL";
        cb_eliminacio.SelectedItem = "ELIMINAR INVALIDOS";

        dgrid_datos.AutoGenerateColumns = false;
        dgrid_datos.Columns.Add("Name", "Name");
        dgrid_datos.Columns.Add("Surname", "Surname");
        dgrid_datos.Columns.Add("Gender", "Gender");
        dgrid_datos.Columns.Add("Company", "Company");
        dgrid_datos.Columns.Add("Email", "Email");
        dgrid_datos.Columns.Add("Country", "Country");
        dgrid_datos.Columns.Add("Dni", "Dni");

        dgrid_datos.AutoResizeColumnHeadersHeight();
    }


    /*
     * LINQ
     */
    private static async Task<List<Person>> ValidatePersonDataLinq(IEnumerable<Person> personList)
    {
        var result = personList
            .Where(persona => persona.CheckDni() && persona.CheckName() && persona.CheckMail()).ToList();
        return await Task.FromResult(result);
    }

    private static async Task<List<Person>> InvalidPersonDataLinq(IEnumerable<Person> personList)
    {
        var result = personList
            .Where(persona => !persona.CheckDni() || !persona.CheckName() || !persona.CheckMail()).ToList();
        return await Task.FromResult(result);
    }

    /*
     * SEQUENCIAL
     */
    private static Task<List<Person>> ValidatePersonDataSeq(IEnumerable<Person> personList)
    {
        var validPersons = new List<Person>();
        foreach (var person in personList)
            if (person.CheckDni() && person.CheckName() && person.CheckMail())
                validPersons.Add(person);

        return Task.FromResult(validPersons);
    }

    private static Task<List<Person>> InvalidPersonDataSeq(IEnumerable<Person> personList)
    {
        var invalidPersons = new List<Person>();
        foreach (var person in personList)
            if (!person.CheckDni() || !person.CheckName() || !person.CheckMail())
                invalidPersons.Add(person);
        return Task.FromResult(invalidPersons);
    }

    private async Task<List<Person>> InValidPerson(string runMode)
    {
        List<Person> personesInvalides;
        if (runMode == "SEQUENCIAL")
            personesInvalides = await InvalidPersonDataSeq(_persons);
        else
            personesInvalides = await InvalidPersonDataLinq(_persons);

        var numPersonas = _persons.Count;
        var numInvalidas = personesInvalides.Count;
        var numValidas = numPersonas - numInvalidas;

        label_num_validas.Text = numValidas + @"/" + numPersonas;
        label_num_invalidas.Text = numInvalidas + @"/" + numPersonas;

        return personesInvalides;
    }

    private async Task<List<Person>> ValidPerson(string runMode)
    {
        List<Person> personesValides;
        if (runMode == "SEQUENCIAL")
            personesValides = await ValidatePersonDataSeq(_persons);
        else
            personesValides = await ValidatePersonDataLinq(_persons);

        var numPersonas = _persons.Count;
        var numValidas = personesValides.Count;
        var numInvalidas = numPersonas - numValidas;

        label_num_validas.Text = numValidas + @"/" + numPersonas;
        label_num_invalidas.Text = numInvalidas + @"/" + numPersonas;

        return personesValides;
    }

    private void ButtonInsertDataFromFile(object sender, EventArgs e)
    {
        GetDataFromJson();
    }

    private async void ButtonFilterDataFromFilter(object sender, EventArgs e)
    {
        if (!_canPocessData) return;
        _filtredPersons = new List<Person>();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (cb_eliminacio.Text == @"DELETE INVALID")
            _filtredPersons = await ValidPerson(cb_modoUso.Text);
        else
            _filtredPersons = await InValidPerson(cb_modoUso.Text);

        SetData(_filtredPersons);

        stopwatch.Stop();
        var segundos = (float)stopwatch.ElapsedMilliseconds / 1000;
        if (cb_modoUso.Text == @"SEQUENCIAL")
            tb_seq.Text = segundos.ToString(CultureInfo.CurrentCulture);
        else
            tb_linq.Text = segundos.ToString(CultureInfo.CurrentCulture);
    }

    private void dgrid_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}