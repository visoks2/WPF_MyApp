using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataProvider
{
    [AttributeUsage(AttributeTargets.Class)
]
    public class DataLocationAttribute : Attribute
    {
        private string _fileName;
        public string FileName => _fileName;
        public DataLocationAttribute(string fileName)
        {
            _fileName = fileName;
        }
    }
}
