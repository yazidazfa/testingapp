using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfTestingApp.model
{
    internal class ClassList
    {
        private List<string>? list = new List<string>();
        public List<string>? nameList
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }
    }
}