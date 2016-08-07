using RentalCar.BL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRentalCar
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> data = new List<string>();
            int startIndex = 0;

            data = CsvFileReader.ReadDataFromCsv("D:\\Work\\RentalCar\\Car-Models-List-by-Teoalida-SAMPLE.csv");
            startIndex = CsvFileReader.GetStartIndex(data);
            data = CsvFileReader.PrepareList(data, startIndex);
            data = CsvFileReader.FilterDataList(data);
        }
    }
}
