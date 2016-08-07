using RentalCar.BL.Services;
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
            CarService.AddCar(int.Parse(registrationTextBox.Text), Int32.Parse(locationComboBox.SelectedValue.ToString()), 
                              Int32.Parse(brandComboBox.SelectedValue.ToString()), 
                              Int32.Parse(modelComboBox.SelectedValue.ToString()));

            messageSaveLabel.Text = "The car has been succesfully added! ";
            messageSaveLabel.ForeColor = System.Drawing.Color.Green;
            messageSaveLabel.Show();
        }
    }
}
