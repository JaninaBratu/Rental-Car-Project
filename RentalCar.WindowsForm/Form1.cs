using RentalCar.BL.Services;
using RentalCar.BL.Util;
using RentalCar.DAL;
using RentalCar.Model;
using RentalCar.WindowsForm.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;



namespace RentalCar.WindowsForm
{
    public partial class Form1 : Form
    {

       private int _currentPage = 1;
       private int _count = 0;
        private const int PAGE_LIMIT = 2;

        public Form1()
        {
            InitializeComponent();
            InitializeAllCombobox();
            InitializeCurrentPageTextBox();
        }

        public Form1(int carId)
        {
            InitializeComponent();
            InitializeAllCombobox();
        }

        private void InitializeDataGrid(List<tblCar> listCars)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.AutoSize = true;

            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "Car Id";
            dataGridView1.Columns[1].Name = "Registration Number";
            dataGridView1.Columns[2].Name = "Location";

            foreach (var rowArray in listCars)
            {
                dataGridView1.Rows.Add(new string[] { rowArray.CarId.ToString(), rowArray.RegistrationNumber.ToString(), rowArray.tblLocation.City.ToString() });
            }
            dataGridView1.Refresh();
        }

        private void InitializeCurrentPageTextBox()
        {
            currentPageNr.Text = _currentPage.ToString();
            currentPageNr.TextAlign = HorizontalAlignment.Center;
        }

               
        private void InitializeAllCombobox()
        {
            InitializeBrandCombobox();
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
            brandCombobox.DataSource = c;

            brandCombobox.DisplayMember = "Text";
            brandCombobox.ValueMember = "Value";

        }

        private void InitializeModelCombobox(int brandId)
        {
            List<tblModel> listOfModels = ModelService.GetModelTypesByBrand(brandId);

            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int i = 0; i < listOfModels.Count; i++)
            {

                c.Add(new ComboboxItem(listOfModels[i].Name.ToString(), listOfModels[i].ModelId));

            }
            modelCombobox.DataSource = c;
            modelCombobox.DisplayMember = "Text";
            modelCombobox.ValueMember = "Value";

        }
        
        private void brandCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modified
            int selectedType = Int32.Parse(brandCombobox.SelectedValue.ToString());
            InitializeModelCombobox(selectedType);
        }


        private void SaveRezervation(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string surname = surnameTextBox.Text;
            float price = float.Parse(priceTextBox.Text);
            
            //Save rezervation
        }

        private void buttonGetListOfCars(object sender, EventArgs e)
        {
           
           InitializeDataGrid(CarService.GetFilteredList(PAGE_LIMIT, PageAction.CalculateOffset(_currentPage, PAGE_LIMIT)));
        }

        private void CalculatePrice(object sender, EventArgs e)
        {
            try
            {
                var cellIndex = dataGridView1.CurrentCell.RowIndex;
                int carId = int.Parse(dataGridView1.Rows[cellIndex].Cells[0].Value.ToString());
                var car = CarService.GetCarById(carId);
                UpdateRentPrice(car.tblModel.PricePerDay.ToString());
            }
            catch
            {
                throw;
            }
        }

        private void UpdateRentPrice(string pricePerDay)
        {
            DateTime dateFrom = dateTimePicker1.Value.Date;
            DateTime dateTo = dateTimePicker2.Value.Date;

            var days = ((dateTo - dateFrom).TotalDays) + 1;

            var rentPrice = float.Parse(pricePerDay) * days;

            priceTextBox.Text = rentPrice.ToString();

        }

        private void CheckedCarId(object sender, EventArgs e)
        {
            List<tblCar> listOfCars = GetListCarsByModel();

            if (CarIdCheck.Checked)
            {
                InitializeDataGrid(CarService.OrderAscByRegistrNr(listOfCars));
            }
        }

        //get all the cars by model
        public List<tblCar> GetListCarsByModel()
        {
            int modelId = Int32.Parse(modelCombobox.SelectedValue.ToString());
            List<tblCar> listOfCars = CarService.GetListCarsByModel(modelId);
            return listOfCars;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage = Int32.Parse(currentPageNr.Text.ToString());
            _currentPage++;
            double offset = PageAction.CalculateOffset(_currentPage, PAGE_LIMIT);
            List<tblCar> listOfCars = CarService.GetFilteredList(PAGE_LIMIT, offset);
            InitializeDataGrid(listOfCars);
            currentPageNr.Text = _currentPage.ToString();
            currentPageNr.TextAlign = HorizontalAlignment.Center;
        }
        

        private void buttonAddClicked(object sender, EventArgs e)
        {
            Hide();
            AddCarsForm addForm = new AddCarsForm();
            addForm.Show();
        }

    }

}
