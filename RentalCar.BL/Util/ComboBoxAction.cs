using RentalCar.WindowsForm.Services;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCar.WindowsForm.Util
{
    // sa incercam sa extindem clasa Form1 si vedem daca avem acces la combobox-uri
    public class ComboBoxAction : Form
    {


        public static void InitializeBrandCombobox(ComboBox brandComboBox, ComboBox modelComboBox)
        {
            List<tblBrand> listOfBrands = BrandService.GetBrandTypes();

            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int i = 0; i < listOfBrands.Count; i++)
            {

                c.Add(new ComboboxItem(listOfBrands[i].Name.ToString(), listOfBrands[i].BrandId));

                if (i == 0)
                {
                    InitializeModelCombobox(listOfBrands[i].BrandId, modelComboBox);
                }

            }
            brandComboBox.DataSource = c;

            brandComboBox.DisplayMember = "Text";
            brandComboBox.ValueMember = "Value";

        }

        public static void InitializeModelCombobox(int brandId, ComboBox modelComboBox)
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

    }
}
