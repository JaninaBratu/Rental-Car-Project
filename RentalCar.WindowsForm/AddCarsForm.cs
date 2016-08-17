using RentalCar.WindowsForm.Services;
using RentalCar.Model;
using RentalCar.WindowsForm.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCar.WindowsForm
{
    public partial class AddCarsForm : Form
    {
        public AddCarsForm()
        {
            InitializeComponent();
            InitializeAllCombobox();
            SetVisibilityLabel();
        }

        private void SetVisibilityLabel()
        {
            messageSaveLabel.Hide();
        }

        private void InitializeAllCombobox()
        {
            InitializeBrandCombobox();
            InitializeLocationCombobox();
        }

        private void InitializeBrandCombobox()
        {
            List<tblBrand> listOfBrands = BrandService.GetBrandTypes();

            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int i = 0; i < listOfBrands.Count; i++)
            {

                c.Add(new ComboboxItem(listOfBrands[i].Name.ToString(), listOfBrands[i].BrandId));

                if (i == 0)
                {
                    InitializeModelCombobox(listOfBrands[i].BrandId);
                }
            }
            brandComboBox.DataSource = c;

            brandComboBox.DisplayMember = "Text";
            brandComboBox.ValueMember = "Value";
        }

        private void InitializeModelCombobox(int brandId)
        {
            List<tblModel> listOfModels = ModelService.GetModelTypesByBrand(brandId);

            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int i = 0; i < listOfModels.Count; i++)
            {

                c.Add(new ComboboxItem(listOfModels[i].Name.ToString(), listOfModels[i].ModelId));
            }
            modelComboBox.DataSource = c;

            modelComboBox.DisplayMember = "Text";
            modelComboBox.ValueMember = "Value";
        }

        private void InitializeLocationCombobox()
        {
            List<tblLocation> listOfLocations = LocationService.GetAllLocations();
            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int j = 0; j < listOfLocations.Count; j++)
            {
                c.Add(new ComboboxItem(listOfLocations[j].Name.ToString(), listOfLocations[j].LocationId));
            }
                locationComboBox.DataSource = c;
                locationComboBox.DisplayMember = "Text";
                locationComboBox.ValueMember = "Value";
        }

        private void backButtonOnClick(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int registrationNumber = Int32.Parse(registrationTextBox.Text.ToString());
            int location = Int32.Parse(locationComboBox.SelectedValue.ToString());
            int brand = Int32.Parse(brandComboBox.SelectedValue.ToString());
            int model = Int32.Parse(modelComboBox.SelectedValue.ToString());

            // validation

            int resultOfValidation = CarAction.ValidateRegistrationNumber(registrationNumber);
            if (resultOfValidation == 1)
            {
                int resultRegistrationNumber = CarService.CheckRegistrationNumber(registrationNumber);
                if (resultRegistrationNumber == -1)
                {
                    CarService.AddCar(registrationNumber, location, brand, model);
                    SetMessageLabel("The car has been succesfully added! ");
                }
                else
                {
                    SetMessageLabel("This car is already in the database!");
                }
            }
            else if (resultOfValidation == -1)
            {
                SetMessageLabel
                    ("The registration number is LESS than the number of digits accepted. The number must be exactly 7 digits!");
            }
            else if (resultOfValidation == -2)
            {
                SetMessageLabel
                    ("The registration number is GREATER than the number of digits accepted. The number must be exactly 7 digits!");

            }
            else if (resultOfValidation == -3)
            {
                SetMessageLabel("The registration number you want to save is not valid. It must be a number of exactly 7 digits!");
            }
            
        }

        public void SetMessageLabel(string message)
        {
            messageSaveLabel.Text = message;
            messageSaveLabel.ForeColor = System.Drawing.Color.Red;
            messageSaveLabel.Show();
        } 
    }
}
