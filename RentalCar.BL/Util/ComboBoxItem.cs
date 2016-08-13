

namespace RentalCar.WindowsForm.Util
{
    public class ComboboxItem
    {
        string text;
        int value;

        public string Text
        {
            get
            {
                return text;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public ComboboxItem(string text, int value)
        {
            this.text = text;
            this.value = value;
        }
    }
}
