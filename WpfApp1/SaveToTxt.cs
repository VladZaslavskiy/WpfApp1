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
            string path = @"C:\Projects\SimpleNavigation\WpfApp1\WpfApp1\Resourses\TextFile1.txt";

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
    }
}
