using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.WindowsForm.Util
{
    public class CsvFileReader
    {
        public static List<string> ReadDataFromCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            List<string> listRows = new List<string>();
            while (!reader.EndOfStream)
            {
                listRows.Add(reader.ReadLine());
            }
            return listRows;
        }


        public static int GetStartIndex(List<string> listRows)
        {
            int count = 0;
            

            for(int i=0; i<listRows.Count; i++)
            {
                if (listRows[i].Equals(",,,,,,,,,,,"))
                {
                    count++;
                }
                if (count == 4)
                {
                    return i + 1;
                }
            }
            return 0;
        }


        public static List<string> PrepareList(List<string> listRows, int startIndex)
        {
            List<string> data = new List<string>();

            for(int i= startIndex; i<listRows.Count; i++)
            {
                data.Add(listRows[i]);
            }
            return data;
        }

        public static List<string> FilterDataList(List<string> listData)
        {
            string[] splittedData = null;
            List<string> resultList = new List<string>();

            for(int i=0; i<listData.Count; i++)
            {
                splittedData = listData[i].Split(',');
                resultList.Add(splittedData[0]);
                resultList.Add(splittedData[1]);
                splittedData = null;
            }
            return resultList;
        }

    }
}
