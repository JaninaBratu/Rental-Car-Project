using RentalCar.WindowsForm.Services;
using RentalCar.WindowsForm.Util;
using RentalCar.DAL;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RentalCar.BL;


namespace RentalCar.WindowsForm
{
    public partial class Form1 : Form
    {

       private int _currentPage = 0;
       private const int PAGE_LIMIT = 2;

        public Form1()
        {
            InitializeComponent();
            InitializeAllCombobox();
            TextBoxAction.InitializeCurrentPageTextBox(currentPageTextBox, _currentPage);
            SetEnable();
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

        
        //setenable este ok; daca am stii si cui; presupun ca e logic si nu ma prind eu
        private void SetEnable()
        {
            //remove the argument; is a protected variable
            bool enablePrevious = IsFirstPage(_currentPage);

            // is ok; but i think is better if we try: _currnetPage > 2
            if (enablePrevious)
            {
                nextButton.Enabled = false;
                previousButton.Enabled = false;
            }
        }
        //cui? vezi poate nu-ti trebuie
        private void ResetEnable(int currentPage)
        {
            if (currentPage >= 1)
            {
                nextButton.Enabled = true;
            }
        }

        private void InitializeAllCombobox()
        {
            ComboBoxAction.InitializeBrandCombobox(brandCombobox, modelCombobox);
        }

        
        private void brandCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selectVal = brandCombobox.SelectedValue;
            //var brandId = selectVal.Value.ToString();

            //modified
            //int selectedType = Int32.Parse(brandCombobox.SelectedValue.ToString());
            ComboBoxAction.InitializeModelCombobox(1, modelCombobox);
        }


        private void SaveRezervation(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string surname = surnameTextBox.Text;
            float price = float.Parse(priceTextBox.Text);
            
        }

        private void buttonGetListOfCars(object sender, EventArgs e)
        {
            _currentPage = ++_currentPage;

            //de unde stii ca exista pagina 2; inainte sa iei elementele sau sa verifici cate pagini sunt maxim
            ResetEnable(_currentPage);

            TextBoxAction.InitializeCurrentPageTextBox(currentPageTextBox, _currentPage);
            //fa-i variabile pt argumente
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
            _currentPage = TextBoxAction.GetPreviousValueForPage(currentPageTextBox);
            bool enablePrevious = IsFirstPage(_currentPage);
            // de ce nu verifi si daca este ultimul (next)

            if(enablePrevious)
            {
                previousButton.Enabled = false;
                //next nu este verificat
                nextButton.Enabled = true;
                TextBoxAction.SetPreviousValueForPage(currentPageTextBox);
            }
            else
            {
                TextBoxAction.InitializeCurrentPageTextBox(currentPageTextBox, _currentPage);
            }

            double offset = PageAction.CalculateOffset(_currentPage, PAGE_LIMIT);
            List<tblCar> listOfCars = CarService.GetFilteredList(PAGE_LIMIT, offset);
            InitializeDataGrid(listOfCars);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage = TextBoxAction.GetNextValueForPage(currentPageTextBox);
            bool enableNext = IsLastPage(_currentPage);

            if (enableNext)
            {
                nextButton.Enabled = false;
                previousButton.Enabled = true;
                TextBoxAction.SetNextValueForPage(currentPageTextBox);
            }
            else
            {
                if (Int32.Parse(currentPageTextBox.Text.ToString()) == 1)
                {}
                else
                {
                    nextButton.Enabled = true;
                    previousButton.Enabled = true;
                }
            }

            double offset = PageAction.CalculateOffset(_currentPage, PAGE_LIMIT);
            List<tblCar> listOfCars = CarService.GetFilteredList(PAGE_LIMIT, offset);
            InitializeDataGrid(listOfCars);
        }

        private bool IsLastPage(int _currentPage)
        {
            
            int nrOfCars = CarService.GetTotalNrOfCars();
            int nrOfPages = Convert.ToInt32(PageAction.GetNrOfPages(nrOfCars, PAGE_LIMIT));

            if (_currentPage == nrOfPages)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFirstPage(int _currentPage = 1)
        {
            if (_currentPage > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonAddClicked(object sender, EventArgs e)
        {
            Hide();
            AddCarsForm addForm = new AddCarsForm();
            addForm.Show();
        }

    }

}
