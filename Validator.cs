using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace BRWildlife
{
    public static class Validator
    {
        //Validates all animal fields according to the rules defined in Section 3 of the Project

        public static bool ValidateAnimal(
            string id,
            string name,
            string species,
            string age,
            string score,
            bool isNewRecord,
            List<Animal> existingAnimals,
            out string errorMessage)

        {
            errorMessage = "";

            //1. Animal ID Validation
            if (isNewRecord)
            {

                if (string.IsNullOrWhiteSpace(id))
                {
                    errorMessage = "Animal ID is required";
                    return false;
                }

                id = id.Trim().ToUpper();
                if (!Regex.IsMatch(id, @"^WR-\d{4}$"))
                {
                    errorMessage = "Animal ID must be in the format WR- followed by four digits (e.g. WR-0007)";
                    return false;
                }

                if (existingAnimals.Any(a => a.ID.Equals(id, StringComparison.OrdinalIgnoreCase)))
                {
                    errorMessage = $"An animal with ID '{id}' already exists. The ID must be unique";
                    return false;
                }

            }//end of if(isNewRecord)


            //2. Name Validation 
            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Name is required";
                return false;
            }

            name = name.Trim();
            if (name.Length > 30 || name.Contains('|'))
            {
                errorMessage = "Name must be between 1 and 30 characters and must not contain the pipe(|) character";
                return false;
            }


            //3. Species Validation
            if (string.IsNullOrWhiteSpace(species))
            {
                errorMessage = "Species is required";
                return false;
            }

            species = species.Trim();
            if (species.Length > 30 || species.Contains('|'))
            {
                errorMessage = "Species must be between 1 and 30 characters and must not contain the pipe(|) character";
                return false;
            }


            //4. Age Validation 
            if (!int.TryParse(age.Trim(), out int _age) || _age < 0 || _age > 100)
            {
                errorMessage = "Age must be a whole number from 0 to 100";
                return false;
            }


            //5. Recovery Score Validation
            if (!int.TryParse(score.Trim(), out int _score) || _score < 0 || _score > 100)
            {
                errorMessage = "Recovery Score must be a whole number between 0 and 100";
                return false;
            }

            return true;
                

        }//end of ValidateAnimal method
    

    }//end of Validator Class
}
