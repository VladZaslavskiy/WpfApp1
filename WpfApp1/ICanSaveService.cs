using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public interface ICanSaveService
    {
        public void Save(PersonModel personModel);
    }
}
