using RentalCar.WindowsForm.Services;
using RentalCar.WindowsForm.Util;
using RentalCar.DAL;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RentalCar.BL;
using System.Text.RegularExpressions;

namespace RentalCar.WindowsForm
{
    public partial class Form1 : Form
    {

       //private int _currentPage = 0;
       private const int PAGE_LIMIT = 2;

        public Form1()
        {
            InitializeComponent();
            InitializeAllCombobox();
                       
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
            bool pageExists;
            if (currentPageTextBox.Text.ToString() == "")
            {
                pageExists = true;
            }
            else
            {
                pageExists = IfPageExists();
            }

            if (pageExists)
            {
                labelMessage.Hide();

                int currentPage = GetCurrentPage(currentPageTextBox.Text.ToString());
                int rightNeighborValue = currentPage + 1;
                if (currentPage > 1)
                {
                    int leftNeighbourValue = currentPage - 1;
                    leftNeighbor.Text = leftNeighbourValue.ToString();
                }

                DisplayCars(currentPage);
                TextBoxAction.SetPageNr(currentPageTextBox, currentPage);

                rightNeighbor.Text = rightNeighborValue.ToString();
            }
            else
            {
                labelMessage.Text = "There is no result for the input value!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Show();
            }
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
            bool pageExists = IfPageExists();
            if (pageExists)
            {
                int currentPage = Int32.Parse(currentPageTextBox.Text.ToString());
                if (currentPage > 1)
                {
                    int newCurrentPage = currentPage - 1;

                    int leftNeighbourValue = newCurrentPage - 1;
                    int rightNeighbourValue = currentPage;

                    DisplayCars(newCurrentPage);
                    TextBoxAction.SetPageNr(currentPageTextBox, newCurrentPage);

                    leftNeighbor.Text = leftNeighbourValue.ToString();
                    rightNeighbor.Text = rightNeighbourValue.ToString();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool pageExists = IfPageExists();
            if (pageExists)
            {
                int currentPage = Int32.Parse(currentPageTextBox.Text.ToString());
                int newCurrentPage = currentPage + 1;

                int leftNeighbourValue = currentPage;
                int rightNeighbourValue = newCurrentPage + 1;

                DisplayCars(newCurrentPage);
                TextBoxAction.SetPageNr(currentPageTextBox, newCurrentPage);

                leftNeighbor.Text = leftNeighbourValue.ToString();
                rightNeighbor.Text = rightNeighbourValue.ToString();
            }
        }

        private void buttonAddClicked(object sender, EventArgs e)
        {
            Hide();
            AddCarsForm addForm = new AddCarsForm();
            addForm.Show();
        }

        private int GetCurrentPage(string currentPage)
        {
            bool isNumber = Microsoft.VisualBasic.Information.IsNumeric(currentPage);
            
            if (!isNumber)
            {
                currentPage = "1";
            }
            return Int32.Parse(currentPage);
        }

        private bool IfPageExists()
        {
            string currentPageStringValue = currentPageTextBox.Text.ToString();
            //is character
            if (Regex.IsMatch(currentPageStringValue, @"^[a-zA-Z]+$") && (!Regex.IsMatch(currentPageStringValue, @"^\d$")))
            {
                return false;
            }
            //is number
            else if(!Regex.IsMatch(currentPageStringValue, @"^[a-zA-Z]+$") && (Regex.IsMatch(currentPageStringValue, @"^\d$")))
            {
                int nrOfCars = CarService.GetTotalNrOfCars();
                int nrOfPages = Convert.ToInt32(PageAction.GetNrOfPages(nrOfCars, PAGE_LIMIT));
                int currentPageIntValue = Int32.Parse(currentPageTextBox.Text.ToString());

                if (currentPageIntValue <= nrOfPages)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //is special character
            else 
            {
                return false;
            }
        }

        private void DisplayCars(int currentPage)
        {
            int nrOfCars;
            int nrOfPages;
            
            nrOfCars = CarService.GetTotalNrOfCars();

            if(nrOfCars > 0)
            {
                nrOfPages = Convert.ToInt32(PageAction.GetNrOfPages(nrOfCars, PAGE_LIMIT));
                double offset = PageAction.CalculateOffset(currentPage, PAGE_LIMIT);
                List<tblCar> listOfCars = CarService.GetFilteredList(PAGE_LIMIT, offset);
                InitializeDataGrid(listOfCars);


                if (currentPage == 1)
                {
                    previousButton.Visible = false;
                    leftNeighbor.Visible = false;
                }
                else if (currentPage > 1 && currentPage < nrOfPages)
                {
                    previousButton.Visible = true;
                    nextButton.Visible = true;
                    rightNeighbor.Visible = true;
                    leftNeighbor.Visible = true;
                }
                else if (currentPage == nrOfPages)
                {
                    previousButton.Visible = true;
                    leftNeighbor.Visible = true;
                    nextButton.Visible = false;
                    rightNeighbor.Visible = false;
                }
                else if(currentPage > nrOfPages)
                {
                    labelMessage.Text = "There is no result for the input value!";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                labelMessage.Text = "There is no result for the input value!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }

}
