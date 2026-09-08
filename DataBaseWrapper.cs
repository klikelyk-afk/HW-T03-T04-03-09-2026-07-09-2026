using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HW_T03_T04_03_09_2026_07_09_2026
{
    public class VeterinaryContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Veterinary.db");
        }
    }

    [Table(nameof(VeterinaryContext.Animals))]
    public class Animal
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public int YearOfBirth { get; set; }
        public int YearOfVaccination { get; set; }
        public string AnimalType { get; set; } = string.Empty;
        public string BreedType { get; set; } = string.Empty;

        [NotMapped]
        public bool IsVaccinatedActual => YearOfVaccination >= DateTime.Now.Year;

        [NotMapped]
        public string VaccinationStatus => IsVaccinatedActual ? "Актуальна" : "Потребує вакцинації";

        public override string ToString() => Name;
    }

    public class DbHandler
    {
        public VeterinaryContext DbContext { get; private set; } = new VeterinaryContext();

        public DbHandler()
        {
        }

        public void CloseConnection()
        {
            DbContext?.Dispose();
        }

        public void Init(bool recrate = true, bool setDummyData = true)
        {
            if (recrate)
            {
                DbContext.Database.EnsureDeleted();
            }

            DbContext.Database.EnsureCreated();

            if (setDummyData)
            {
                SetDummyData();
            }
        }

        private void SetDummyData()
        {
            if (DbContext.Animals.Count() == 0)
            {
                DbContext.Animals.AddRange(
                    new Animal() { Name = "Rex", OwnerName = "Petrenko", YearOfBirth = 2019, YearOfVaccination = 2026, AnimalType = "Dog", BreedType = "German Shepherd" },
                    new Animal() { Name = "Luna", OwnerName = "Smith", YearOfBirth = 2021, YearOfVaccination = 2025, AnimalType = "Cat", BreedType = "Siamese" },
                    new Animal() { Name = "Oliver", OwnerName = "Garcia", YearOfBirth = 2015, YearOfVaccination = 2024, AnimalType = "Cat", BreedType = "Maine Coon" },
                    new Animal() { Name = "Bella", OwnerName = "Muller", YearOfBirth = 2019, YearOfVaccination = 2026, AnimalType = "Dog", BreedType = "French Bulldog" },
                    new Animal() { Name = "Charlie", OwnerName = "Tanaka", YearOfBirth = 2022, YearOfVaccination = 2026, AnimalType = "Dog", BreedType = "Beagle" },
                    new Animal() { Name = "Simba", OwnerName = "Dubois", YearOfBirth = 2020, YearOfVaccination = 2025, AnimalType = "Cat", BreedType = "Bengal" },
                    new Animal() { Name = "Daisy", OwnerName = "Pylypenko", YearOfBirth = 2017, YearOfVaccination = 2024, AnimalType = "Dog", BreedType = "Border Collie" },
                    new Animal() { Name = "Cooper", OwnerName = "Wilson", YearOfBirth = 2023, YearOfVaccination = 2026, AnimalType = "Dog", BreedType = "Poodle" },
                    new Animal() { Name = "Nala", OwnerName = "Lee", YearOfBirth = 2016, YearOfVaccination = 2025, AnimalType = "Cat", BreedType = "Persian" },
                    new Animal() { Name = "Max", OwnerName = "Schmidt", YearOfBirth = 2014, YearOfVaccination = 2026, AnimalType = "Dog", BreedType = "German Shepherd" }
                );
                DbContext.SaveChanges();
            }
        }

        public void AddNewAnimal(string name, string owner, int year, int vaccination)
        {
            var newAnimal = new Animal()
            {
                Name = name,
                OwnerName = owner,
                YearOfBirth = year,
                YearOfVaccination = vaccination
            };

            AddNewAnimal(newAnimal);
        }

        public void AddNewAnimal(Animal animal)
        {
            if (animal != null)
            {
                DbContext.Animals.Add(animal);
                DbContext.SaveChanges();
            }
        }

        public void RemoveAnimal(Animal animal)
        {
            if (animal != null)
            {
                DbContext.Animals.Remove(animal);
                DbContext.SaveChanges();
            }
        }
    }
}