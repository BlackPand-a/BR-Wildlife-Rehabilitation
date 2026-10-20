# Baobab Ridge Wildlife Rehabilitation  System

## Project Description
This is a C# Windows Forms application developed to help a wildlife rehabilitation centre manage animal records.

Baobab Ridge Wildlife Rehabilitation Centre treats injured and orphaned wild animals and returns them to the wild once they are read

# Group Members
- Member 1: Nicholas Grobler 603919
- Member 2: Etienne Koen 603405
- Member 3: Erich lorenz 600172
- Member 4: Letago Ngalava Makhubele 604123

# Technologies Used
- C#
- Windows Forms
- .NET 8.0
- Visual Studio
- Git and GitHub
- Text files for storing data

# System Features
- Add Animal: Adds a new animal record.
- View Animals: Displays animal records in a table.
- Update Animal: Changes an existing animal's details.
- Delete Animal: Deletes a selected animal after confirmation.
- Generate Summary: Displays animal statistics and creates a report.

## How to Run the Program
1. Download or clone the GitHub repository.
2. Open BRWildlife.slnx in Visual Studio.
3. Build the solution.
4. Press F5 to run the application.

## Text Files

# animals.txt
Stores the animal records using the following format:

ID,Name,Species,Age,Score,Status,Housing Unit

Each animal is stored on a separate line.

# summary.txt
Created when the user generates a summary report.

It contains the total number of animals, average age, average recovery score and the number of animals in each status.

The file is overwritten each time a new report is generated.

# Testing and Conclusion
The Delete Animal and Generate Summary Report features were implemented and tested successfully.
Both features worked as expected during testing.