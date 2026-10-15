namespace BRWildlife;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private int RefreshGrid()
    {
        // Stop file loading from running while the Visual Studio designer is open
        if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
        {
            return 0;
        }

        //RefreshGrid loads the animals, rebinds the grid and returns the skipped count 
        var results = AnimalFileHandler.Load();
        dgvAnimals.DataSource = null;
        dgvAnimals.DataSource = results.Animals;
        return results.Skipped;
    }


    // This just shows the amount of lines skipped during the startup.
    private void Form1_Load(object sender, EventArgs e)
    {
        var skipped = RefreshGrid();
        if (skipped > 0)
        {
            MessageBox.Show($"{skipped} were skipped because they were not vaild.");
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        //load existing records to check Animal ID uniqueness against the file
        var loadResult = AnimalFileHandler.Load();
        List<Animal> existingAnimals = loadResult.Animals;


        //Gather input from text boxes
        string id = txtAnimalID.Text;
        string name = txtName.Text;
        string species = txtSpecies.Text;
        string age = txtAge.Text;
        string recoveryScore = txtRecoveryScore.Text;


        //Validate using the Validator method
        if (!Validator.ValidateAnimal(id, name, species, age, recoveryScore, true, existingAnimals, out string errorMessage))
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK);
            return;
        }


        //Clean and parse valid inputs
        string cleadID = id.Trim().ToUpper();
        string cleanName = name.Trim();
        string cleanSpecies = species.Trim();
        int score = int.Parse(recoveryScore.Trim());


        //Calculating Status and Housing Unit 
        var classification = Classifier.Classify(score);
        string status = classification.Item1;
        string housingUnit = classification.Item2;


        //Format the user input to match pip character structure 
        string newLine = $"{cleadID} | {cleanName} | {cleanSpecies} | {age} | {score} | {status} | {housingUnit}";
        try
        {
            //Append one line to animals.txt
            File.AppendAllLines("animals.txt", new[] {newLine}, System.Text.Encoding.UTF8);

            //Confirmation message displaying calculated status and housing unit 
            MessageBox.Show(
                $"Animal Added Successfully!\nStatus: {status}",
                $"\nHousing Unit: {housingUnit}" +
                $"Succes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Error saving record: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        RefreshGrid();

        txtAnimalID.Clear();
        txtName.Clear();
        txtSpecies.Clear();
        txtAge.Clear();
        txtRecoveryScore.Clear();
    }
}
