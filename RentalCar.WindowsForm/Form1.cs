using RentalCar.BL.Services;
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

        int PageNumber = 0;
        int CurrentStart = -1;
        int CurrentEnd = -1;

        public Form1()
        {
            InitializeComponent();
            InitializeAllCombobox();
            InitializePageNrDefault();
        }

        public Form1(int carId)
        {
            InitializeComponent();
            InitializeAllCombobox();
            InitializePageNrDefault();
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


        private void InitializePageNrDefault()
        {
            PageNumber += 1;
            pageNr.Text = PageNumber.ToString();
            pageNr.ReadOnly = true;
            pageNr.TextAlign = HorizontalAlignment.Center;
        }

        private int CalculatePageNr(int value = 0, bool next = true)
        {
            if(next)
            {
               value++;
               return value;
            }
            else
            {
                if(value <=1 )
                {
                    return value;
                }
                else
                {
                    value--;
                    return value;
                }
            }
        }

        private void SetPageNr(int pageNumber)
        {
            pageNr.Text = pageNumber.ToString();
            pageNr.ReadOnly = true;
            pageNr.TextAlign = HorizontalAlignment.Center;
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
            InitializeDataGrid(FilterListForPagination());
            
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
        
        //merge doar pentru primele 4 pagini//
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PageNumber = CalculatePageNr(PageNumber, false);
            
            if (PageNumber == 1)
            {
                CurrentStart = PageNumber - 1;
                CurrentEnd = PageNumber;
            }
            else
            {
                CurrentStart = CurrentEnd - 1;

                if(PageNumber == 2)
                {
                    CurrentEnd = CurrentEnd - 1;
                    CurrentStart = CurrentEnd - 1;
                }
                if(PageNumber == 3)
                {
                    CurrentEnd = PageNumber + 2;
                }
                if(PageNumber == 4)
                {
                    CurrentEnd = PageNumber + 3;
                }    
            }

            InitializeDataGrid(FilterListForPagination(CurrentStart, CurrentEnd));

            SetPageNr(PageNumber); 
        }

        //merge pentru toate paginile///
        private void btnNext_Click(object sender, EventArgs e)
        {
            PageNumber = CalculatePageNr(PageNumber);

            if (PageNumber == 1)
            {
                CurrentStart = PageNumber - 1;
                CurrentEnd = PageNumber;
            }
            else
            {
                CurrentStart = PageNumber;
                CurrentEnd = PageNumber + 1;
            }
            
            InitializeDataGrid(FilterListForPagination(CurrentStart, CurrentEnd));
            SetPageNr(PageNumber);
        }
              
        private List<tblCar> FilterListForPagination(int startPosition = 0, int endPosition = 1)
        {
            List<tblCar> listOfCars = GetListCarsByModel();
            List<tblCar> newListOfCars = new List<tblCar>();
            
            for (int i=startPosition; i<=endPosition; i++)
            {
                if (endPosition < listOfCars.Count)
                {
                    newListOfCars.Add(listOfCars[i]);
                }
                else
                {
                    if ((PageNumber - listOfCars.Count) >= 0)
                    {
                        break;
                    }
                    else
                    {
                        newListOfCars.Add(listOfCars[startPosition]);
                    }
                    break;
                }
            }
            return newListOfCars;
        }

        private void buttonAddClicked(object sender, EventArgs e)
        {
            Hide();
            AddCarsForm addForm = new AddCarsForm();
            addForm.Show();
        }
    }

}
