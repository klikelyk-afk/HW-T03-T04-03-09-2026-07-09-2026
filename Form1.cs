using HW_T03_T04_03_09_2026_07_09_2026;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Drawing;

namespace HW_T03_T04_03_09_2026_07_09_2026
{
    public partial class Form1 : Form
    {
        private DbHandler dbHandler;

        public Form1()
        {
            InitializeComponent();

            animalGridView.MultiSelect = false;
            animalGridView.AllowUserToAddRows = true;
            animalGridView.AllowUserToDeleteRows = false;

            animalGridView.SelectionChanged += AnimalGridView_SelectionChanged;
            animalGridView.CellValueChanged += AnimalGridView_CellValueChanged;
            animalGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDbHandler();
            LoadManual();
        }

        private void InitDbHandler()
        {
            dbHandler = new DbHandler();
            dbHandler.Init(false, true);
        }

        private void LoadManual()
        {
            animalGridView.AutoGenerateColumns = false;
            animalGridView.Columns.Clear();

            animalGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "Name"
            });

            animalGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OwnerName",
                HeaderText = "Owner",
                Name = "OwnerName"
            });

            animalGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "YearOfBirth",
                HeaderText = "Year of birth",
                Name = "YearOfBirth"
            });

            animalGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "YearOfVaccination",
                HeaderText = "Vaccination",
                Name = "YearOfVaccination"
            });

            animalGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VaccinationStatus",
                HeaderText = "Vaccination Status",
                Name = "VaccinationStatus",
                ReadOnly = true
            });

            animalGridView.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "AnimalType",
                HeaderText = "Animal type",
                Name = "AnimalType",
                DataSource = new List<string> { "Cat", "Dog", "Other" },
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                AutoComplete = true
            });

            animalGridView.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "BreedType",
                HeaderText = "Breed type",
                Name = "BreedType",
                DataSource = new List<string> { "German Shepherd", "Siamese", "Maine Coon", "French Bulldog",
                    "Beagle", "Bengal", "Border Collie", "Poodle", "Persian", "Other" },
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                AutoComplete = true
            });

            LoadAuto();
        }

        private void LoadAuto()
        {
            dbHandler.DbContext.Animals.Load();
            animalGridView.DataSource = dbHandler.DbContext.Animals.Local.ToBindingList();
            UpdateVaccinationLabel();
        }

        private Animal GetActualSelected()
        {
            return (Animal)animalGridView.CurrentRow?.DataBoundItem;
        }

        private void UpdateVaccinationLabel()
        {
            Animal selectedAnimal = GetActualSelected();

            if (selectedAnimal == null)
            {
                vaccinationStatusLabel.Text = "Статус: Тваринку не обрано";
                vaccinationStatusLabel.ForeColor = System.Drawing.Color.Black;
                return;
            }

            if (selectedAnimal.IsVaccinatedActual)
            {
                vaccinationStatusLabel.Text = $"Статус для {selectedAnimal.Name}: Вакцинація актуальна";
                vaccinationStatusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                vaccinationStatusLabel.Text = $"УВАГА! {selectedAnimal.Name} потребує вакцинації!";
                vaccinationStatusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void AnimalGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateVaccinationLabel();
        }

        private void AnimalGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            animalGridView.Refresh();
            UpdateVaccinationLabel();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            dbHandler.DbContext.SaveChanges();
            animalGridView.Refresh();
            UpdateVaccinationLabel();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (GetActualSelected() is Animal animalToRemove)
            {
                dbHandler.RemoveAnimal(animalToRemove);
                animalGridView.Refresh();
                UpdateVaccinationLabel();
            }
        }

        private void documentButton_Click(object sender, EventArgs e)
        {
            if (GetActualSelected() is Animal animal)
            {
                GeneratePdf(animal);
            }
        }

        private void GeneratePdf(Animal animal)
        {
            if (animal == null)
                return;

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("Certificate of vaccination")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        column.Spacing(5);

                        column.Item().Text($"Pet name: {animal.Name}").Bold();
                        column.Item().Text($"Type: {animal.AnimalType}");
                        column.Item().Text($"Date of vaccination: {DateTime.Now:dd.MM.yyyy}");

                        column.Item().PaddingTop(10).Element(ComposeSignature);
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Veterinary Helper 2026").Italic();
                    });
                });
            })
            .GeneratePdf($"Vaccine_{animal.Name}.pdf");

            MessageBox.Show($"Certificate for {animal.Name} is ready!");
        }

        private void ComposeSignature(QuestPDF.Infrastructure.IContainer container)
        {
            container.BorderTop(1).PaddingTop(5).Row(row =>
            {
                row.RelativeItem().Text("Vet clinic: [ APPROVED ]");
                row.RelativeItem().AlignRight().Text("Veterinarian: _________________");
            });
        }

        private void animalGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}