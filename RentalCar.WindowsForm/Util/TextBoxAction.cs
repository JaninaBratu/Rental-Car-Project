using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCar.WindowsForm.Util
{
    public class TextBoxAction:Form
    {

        public static int GetNextValueForPage(TextBox textBox)
        {
            int currentPage = Int32.Parse(textBox.Text.ToString());
            currentPage++;
            
            return currentPage;
        }

        public static int GetPreviousValueForPage(TextBox textBox)
        {
            int currentPage = Int32.Parse(textBox.Text.ToString());
            if (currentPage == 1)
            {
                return currentPage;
            }
            else
            {
                currentPage--;
                return currentPage;
            }
        }

        public static TextBox SetNextValueForPage(TextBox textBox)
        {
            textBox.Text = GetNextValueForPage(textBox).ToString();
            textBox.TextAlign = HorizontalAlignment.Center;

            return textBox;
        }

        public static TextBox SetPreviousValueForPage(TextBox textBox)
        {
            textBox.Text = GetPreviousValueForPage(textBox).ToString();
            textBox.TextAlign = HorizontalAlignment.Center;

            return textBox;
        }

        public static void InitializeCurrentPageTextBox(TextBox textBox, int pageNr)
        {
            if (pageNr == 0)
            {
                textBox.Text = "";
                textBox.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                textBox.Text = pageNr.ToString();
                textBox.TextAlign = HorizontalAlignment.Center;
            }
        }

    }
}
