using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRWildlife
{
    public static class Classifier
    {
        // Works out the status and housing unit from the Recovery Score. This is where the clasification is.

        public static (string Status, string HousingUnit) Classify(int score)
        {
            if ( 0 > score || score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Recovery Score must be a whole number between 0 and 100.");
            }
            else if (score <= 19)
            {
                return ("Critical", "Intensive Care Unit");

            }
            else if (20 <= score && score <= 39)
            {
                return ("Serious", "High-Dependency Ward");

            }
            else if (40 <= score && score <= 59)
            {
                return ("Stable", "Recovery Ward");
            }
            else if (60 <= score && score <= 79)
            {
                return ("Recovering", "Outdoor Enclosure");
            }
            else 
            {
                return ("Release-Ready", "Pre-Release Camp");
            }
          
           

        }
    }
}
