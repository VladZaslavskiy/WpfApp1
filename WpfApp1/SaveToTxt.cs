using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WpfApp1
{
    class SaveToTxt : ISaveToTxtService
    {

        public void SaveToDisc(string text)
        {
            string path = @"C:\Projects\SimpleNavigation\WpfApp1\WpfApp1\Resourses\Person.txt";

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
    }
}
