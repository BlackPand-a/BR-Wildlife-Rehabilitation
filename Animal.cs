namespace BRWildlife;

// Holds the data for one animal record, matching one line of animals.txt.
// It stores the seven fields and does no reading or writing itself.
public class Animal
{
   
    public string ID { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public int Score { get; set; }
    public string Status { get; set; }
    public string HousingUnit { get; set; }

    // All seven fields are set and follow the order in the animal.txt. Status and HousingUnit are calculated.

    public Animal(string id, string name, string species, int age, int score, string status, string housingUnit)
    { 
        this.ID = id;
        this.Name = name;
        this.Species = species;
        this.Age = age;
        this.Score = score;
        this.Status = status;
        this.HousingUnit = housingUnit;
       
        
    }
}