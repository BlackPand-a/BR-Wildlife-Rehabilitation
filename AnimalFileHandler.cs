using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BRWildlife
{
    public static class AnimalFileHandler
    {
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "animals.txt");

        // Loads every valid Animal and counts the lines that had to be skipped.
        public static (List<Animal> Animals, int Skipped) Load()
        {
            var animals = new List<Animal>();
            int skipped = 0;

            try
            {
                if (!File.Exists(FilePath))
                {
                    File.WriteAllText(FilePath, "");
                    return (animals, 0);
                }

                foreach (string line in File.ReadAllLines(FilePath))
                {
                    string[] parts = line.Split('|');

                    if (parts.Length != 7
                        || !Regex.IsMatch(parts[0].Trim(), @"^WR-\d{4}$")
                        || !int.TryParse(parts[3], out int age)
                        || !int.TryParse(parts[4], out int score))
                    {
                        skipped++;
                        continue;
                    }

                    animals.Add(new Animal(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), age, score, parts[5].Trim(), parts[6].Trim()));
                }
            }
            catch (IOException)
            {
                MessageBox.Show("The file is in use by another program. Close it and try again.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to read the file.");
            }

            return (animals, skipped);
        }

        // Rewrites the whole file from the list.
        public static bool SaveAll(List<Animal> animals)
        {
            try
            {
                var lines = animals.Select(a => a.ID + "|" + a.Name + "|" + a.Species + "|" + a.Age + "|" + a.Score + "|" + a.Status + "|" + a.HousingUnit);

                File.WriteAllLines(FilePath, lines);

                return true; // File saved successfully
            }
            catch (IOException)
            {
                MessageBox.Show("The file is in use by another program. Close it and try again.");
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The file is read-only or you do not have permission to write to it.");
                return false;
            }
        }
    }
}

