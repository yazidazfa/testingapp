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

        public List<string> variables = new List<string>();

        public List<string> methods = new List<string>();

        public List<int> methodTarget = new List<int>();
        public List<int> methodId = new List<int>();
        public List<string> methodParameter = new List<string>();

        public ClassDataType(string aClassName, string aSuperClass)
        {
            this.className = aClassName;
            this.superClass = aSuperClass;
        }


    }
}