using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfTestingApp
{
    internal class ClassDataType
    {
        public int id { get; set; }
        public int target { get; set; }
        public string className { get; set; }
        public string superClass { get; set; }

        public ClassDataType(string aClassName, string aSuperClass)
        {
            this.className = aClassName;
            this.superClass = aSuperClass;
        }


    }
}