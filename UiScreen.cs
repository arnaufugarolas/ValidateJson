using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;

namespace ValidateJson;

public partial class UiScreen : Form
{
    private bool _canPocessData;
    private List<Person> _filtredPersons;
    private List<Person> _persons;

    public UiScreen()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cb_modoUso.SelectedItem = "SEQUENCIAL";
        cb_eliminacio.SelectedItem = "ELIMINAR INVALIDOS";

        dgrid_datos.AutoGenerateColumns = false;
        dgrid_datos.Columns.Add("Name", "Nombre");
        dgrid_datos.Columns.Add("Surname", "Apellido");
        dgrid_datos.Columns.Add("Gender", "Direccion");
        dgrid_datos.Columns.Add("Company", "Email");
        dgrid_datos.Columns.Add("Email", "Telefono");
        dgrid_datos.Columns.Add("Country", "País");
        dgrid_datos.Columns.Add("Dni", "Dni");
    }

    private Task GetDataFromJson()
    {

        _persons = new List<Person>();
        var dialog = new OpenFileDialog();
        dialog.Filter = @"Archivos json (*.json)|*.json|Archivos de texto (*.txt)|*.txt";
        if (DialogResult.OK == dialog.ShowDialog())
        {
            tb_pathFile.Text = dialog.FileName;
            if (File.Exists(dialog.FileName))
            {
                var json = File.ReadAllText(dialog.FileName);
                _persons = JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();

                var rows = _persons.Select(p => new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell { Value = p.Name },
                        new DataGridViewTextBoxCell { Value = p.Surname },
                        new DataGridViewTextBoxCell { Value = p.Gender },
                        new DataGridViewTextBoxCell { Value = p.Company },
                        new DataGridViewTextBoxCell { Value = p.Email },
                        new DataGridViewTextBoxCell { Value = p.Country },
                        new DataGridViewTextBoxCell { Value = p.Dni }
                    }
                }).ToArray();

                dgrid_datos.Rows.AddRange(rows);

                _canPocessData = true;
            }

            dialog.Dispose();
        }

        label_total_personas.Text = _persons.Count.ToString();
        label_num_validas.Text = @"?/" + _persons.Count;
        label_num_invalidas.Text = @"?/" + _persons.Count;

        return Task.CompletedTask;
    }

    /*
     * LINQ
     */
    private static async Task<List<Person>> ValidatePersonDataLinq(IEnumerable<Person> personList)
    {
        var result = personList
            .Where(persona => persona.comprova_dni() && persona.comprova_nom() && persona.comprova_mail()).ToList();
        return await Task.FromResult(result);
    }

    private static async Task<List<Person>> InvalidPersonDataLinq(IEnumerable<Person> personList)
    {
        var result = personList.Where(persona =>
            !persona.comprova_dni() || !persona.comprova_nom() || !persona.comprova_mail()).ToList();
        return await Task.FromResult(result);
    }

    /*
     * SEQUENCIAL
     */
    private static Task<List<Person>> ValidatePersonDataSeq(IEnumerable<Person> personList)
    {
        var validPersons = personList
            .Where(persona => persona.comprova_dni() && persona.comprova_nom() && persona.comprova_mail()).ToList();
        return Task.FromResult(validPersons);
    }

    private static Task<List<Person>> InvalidPersonDataSeq(IEnumerable<Person> personList)
    {
        var invalidPersons = personList.Where(persona =>
            !persona.comprova_dni() || !persona.comprova_nom() || !persona.comprova_mail()).ToList();
        return Task.FromResult(invalidPersons);
    }


    private async Task<List<Person>> InValidPerson(string runMode, IEnumerable<Person> personas)
    {
        List<Person> personesInvalides;
        if (runMode == "SEQUENCIAL")
            personesInvalides = await InvalidPersonDataSeq(personas);
        else
            personesInvalides = await InvalidPersonDataLinq(personas);

        var numPersonas = _persons.Count;
        var numInvalidas = personesInvalides.Count;
        var numValidas = numPersonas - numInvalidas;

        label_num_validas.Text = numValidas + @"/" + numPersonas;
        label_num_invalidas.Text = numInvalidas + @"/" + numPersonas;

        return personesInvalides;
    }

    private async Task<List<Person>> ValidPerson(string runMode, IEnumerable<Person> personas)
    {
        List<Person> personesValides;
        if (runMode == "SEQUENCIAL")
            personesValides = await ValidatePersonDataSeq(personas);
        else
            personesValides = await ValidatePersonDataLinq(personas);

        var numPersonas = _persons.Count;
        var numValidas = personesValides.Count;
        var numInvalidas = numPersonas - numValidas;

        label_num_validas.Text = numValidas + @"/" + numPersonas;
        label_num_invalidas.Text = numInvalidas + @"/" + numPersonas;

        return personesValides;
    }

    private async void ButtonInsertDataFromFile(object sender, EventArgs e)
    {
        await GetDataFromJson();
    }

    private async void ButtonFilterDataFromFilter(object sender, EventArgs e)
    {
        if (!_canPocessData) return;
        _filtredPersons = new List<Person>();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (cb_eliminacio.Text == @"ELIMINAR INVALIDOS")
            _filtredPersons = await ValidPerson(cb_modoUso.Text, _persons);
        else
            _filtredPersons = await InValidPerson(cb_modoUso.Text, _persons);
        dgrid_datos.Rows.Clear();
        dgrid_datos.DataSource = null;
        foreach (var personas in _filtredPersons)
            dgrid_datos.Rows.Add(
                personas.Name,
                personas.Surname,
                personas.Gender,
                personas.Company,
                personas.Email,
                personas.Country,
                personas.Dni
            );
        stopwatch.Stop();
        float segundos = stopwatch.ElapsedMilliseconds / 1000;
        if (cb_modoUso.Text == @"SEQUENCIAL")
            tb_seq.Text = segundos.ToString(CultureInfo.CurrentCulture);
        else
            tb_linq.Text = segundos.ToString(CultureInfo.CurrentCulture);
    }

    private void dgrid_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}