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





}
