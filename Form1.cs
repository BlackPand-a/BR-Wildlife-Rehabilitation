namespace BRWildlife;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    // RefreshGrid loads the animals, rebinds the grid and returns the skipped count 
    private int RefreshGrid()
    {
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
  

    private void dgvAnimals_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }
}
