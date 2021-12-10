using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface ICanSaveService
    {
        public Task Save(string text, CancellationToken cancellationToken);
    }
}
