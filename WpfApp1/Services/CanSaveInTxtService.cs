using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace WpfApp1
{
    class CanSaveInTxtService //: ICanSaveService
    {
        public async Task Save(string text, CancellationToken cancellationToken)
        {
            string path = @"C:\Projects\SimpleNavigation\WpfApp1\WpfApp1\Resourses\TextFile1.txt";
            
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
               await sw.WriteLineAsync(text);
                
            }
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
            }

        }

        //public void SaveToDisc(string text)
        //{
            

        //    using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
        //    {
        //        sw.WriteLine(text);
        //    }
        //}
    }
}
