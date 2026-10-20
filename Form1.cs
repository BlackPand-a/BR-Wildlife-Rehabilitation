namespace BRWildlife;

public partial class Form1 : Form
{
    private string? editingAnimalID = null;
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
            File.AppendAllLines("animals.txt", new[] { newLine }, System.Text.Encoding.UTF8);

            //Confirmation message displaying calculated status and housing unit 
            MessageBox.Show(
                $"Animal Added Successfully!\nStatus: {status}",
                $"\nHousing Unit: {housingUnit}" +
                $"Succes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
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

    // Loads an animal into the textboxes and enables edit mode.
    private void EnterEditMode(Animal animal)
    {
        editingAnimalID = animal.ID;

        txtAnimalID.Text = animal.ID;
        txtName.Text = animal.Name;
        txtSpecies.Text = animal.Species;
        txtAge.Text = animal.Age.ToString();
        txtRecoveryScore.Text = animal.Score.ToString();

        txtAnimalID.ReadOnly = true;

        btnAdd.Enabled = false;
        btnSaveChanges.Enabled = true;
    }

    // Clears the input fields and returns the form to add mode.
    private void ResetForm()
    {
        editingAnimalID = null;

        txtAnimalID.Clear();
        txtName.Clear();
        txtSpecies.Clear();
        txtAge.Clear();
        txtRecoveryScore.Clear();

        txtAnimalID.ReadOnly = false;

        btnAdd.Enabled = true;
        btnSaveChanges.Enabled = false;
    }

    // Loads the selected grid row into edit mode.
    private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // A negative row index means the user clicked a column header.
        if (e.RowIndex < 0)
            return;

        // Get the Animal object represented by the clicked row.
        Animal? animal = dgvAnimals.Rows[e.RowIndex].DataBoundItem as Animal;

        if (animal == null)
            return;

        EnterEditMode(animal);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void btnSaveChanges_Click(object sender, EventArgs e)
    {
        // Make sure an animal is currently being edited.
        if (editingAnimalID == null)
        {
            MessageBox.Show("Please select an animal to update.");
            return;
        }

        // Load the latest animal records.
        var result = AnimalFileHandler.Load();
        List<Animal> animals = result.Animals;

        // Find the original animal using its stored ID.
        Animal? animal = animals.FirstOrDefault(a =>
            a.ID.Equals(editingAnimalID, StringComparison.OrdinalIgnoreCase));

        if (animal == null)
        {
            MessageBox.Show("Animal not found. It may have been removed.");
            return;
        }

        // Validate the edited fields without checking ID uniqueness.
        if (!Validator.ValidateAnimal(
            animal.ID,
            txtName.Text,
            txtSpecies.Text,
            txtAge.Text,
            txtRecoveryScore.Text,
            false,
            animals,
            out string errorMessage))
        {
            MessageBox.Show(errorMessage, "Validation Error");
            return;
        }

        // Update the animal's editable properties.
        animal.Name = txtName.Text.Trim();
        animal.Species = txtSpecies.Text.Trim();
        animal.Age = int.Parse(txtAge.Text.Trim());
        animal.Score = int.Parse(txtRecoveryScore.Text.Trim());

        // Recalculate the classification using the new score.
        var classification = Classifier.Classify(animal.Score);

        animal.Status = classification.Status;
        animal.HousingUnit = classification.HousingUnit;

        // Rewrite the file with the updated animal.
        if (!AnimalFileHandler.SaveAll(animals))
        {
            return;
        }

        RefreshGrid();
        ResetForm();

        MessageBox.Show("Animal updated successfully!");
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        string searchID = txtSearchID.Text.Trim();

        if (string.IsNullOrWhiteSpace(searchID))
        {
            MessageBox.Show("Please enter an Animal ID.");
            return;
        }

        var result = AnimalFileHandler.Load();

        Animal? animal = result.Animals.FirstOrDefault(a =>
            a.ID.Equals(searchID, StringComparison.OrdinalIgnoreCase));

        if (animal == null)
        {
            MessageBox.Show("Animal not found.");
            return;
        }

        EnterEditMode(animal);
    private void btndelete_Click(object sender, EventArgs e)
    {
        if (dgvAnimals.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an animal first.");
            return;
        }

        Animal animal = (Animal)dgvAnimals.SelectedRows[0].DataBoundItem;
        DialogResult answer = MessageBox.Show(
            "Delete " + animal.ID + " (" + animal.Name + ")? This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (answer == DialogResult.No)
        {
            return;
        }

        try
        {
            string filePath = Path.Combine(
                AppContext.BaseDirectory, "animals.txt");

            string[] lines = File.ReadAllLines(filePath);

            List<string> remainingAnimals = new List<string>();
            bool found = false;

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (!found && parts.Length == 7 &&
                    parts[0].Trim().Equals(animal.ID,
                    StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                }
                else
                {
                    remainingAnimals.Add(line);
                }
            }

            if (!found)
            {
                MessageBox.Show("Animal not found.");
                return;
            }

            File.WriteAllLines(filePath, remainingAnimals);

            RefreshGrid();
            dgvAnimals.ClearSelection();

            MessageBox.Show("Animal deleted successfully!");
        }
        catch (IOException)
        {
            MessageBox.Show("Error reading or saving animals.txt.");
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("You do not have permission to change animals.txt.");
        }
    }

    private void btnSummary_Click(object sender, EventArgs e)
    {
        List<Animal> animals = AnimalFileHandler.Load().Animals;

        int total = animals.Count;
        int totalAge = 0;
        int totalScore = 0;

        int critical = 0;
        int serious = 0;
        int stable = 0;
        int recovering = 0;
        int releaseReady = 0;

        foreach (Animal animal in animals)
        {
            totalAge += animal.Age;
            totalScore += animal.Score;

            if (animal.Status == "Critical")
                critical++;
            else if (animal.Status == "Serious")
                serious++;
            else if (animal.Status == "Stable")
                stable++;
            else if (animal.Status == "Recovering")
                recovering++;
            else if (animal.Status == "Release-Ready")
                releaseReady++;
        }

        string averageAge = "N/A";
        string averageScore = "N/A";

        if (total > 0)
        {
            averageAge = ((double)totalAge / total).ToString(
                "F2", System.Globalization.CultureInfo.InvariantCulture);

            averageScore = ((double)totalScore / total).ToString(
                "F2", System.Globalization.CultureInfo.InvariantCulture);
        }

        string[] lines =
        {
        "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
        "ANIMAL SUMMARY REPORT",
        "Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
        "----------------------------------------",
        "Total animals:\t\t" + total,
        "Average age (years):\t" + averageAge,
        "Average recovery score:\t" + averageScore,
        "----------------------------------------",
        "Animals per status:",
        "  Critical:\t\t" + critical,
        "  Serious:\t\t" + serious,
        "  Stable:\t\t" + stable,
        "  Recovering:\t" + recovering,
        "  Release-Ready:\t" + releaseReady
    };

        string report = string.Join(Environment.NewLine, lines);
        txtSummary.Text = report;
        try
        {
            string filePath = Path.Combine(
                AppContext.BaseDirectory, "summary.txt");

            File.WriteAllText(filePath, report);

            MessageBox.Show("Summary report generated successfully!");
        }
        catch (IOException)
        {
            MessageBox.Show("Error saving the summary report.");
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("You do not have permission to save the report.");
        }
    }

   
    private void Form1_Shown(object sender, EventArgs e)
    {
        dgvAnimals.ClearSelection();
  

    }

    private void dgvAnimals_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }
}
