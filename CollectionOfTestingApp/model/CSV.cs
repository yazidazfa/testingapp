using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfTestingApp.model
{
    public class Data
    {
        [Name("Number")]
        public string Number { get; set; }

        [Name("Object Name")]
        public string Objects { get; set; }

        [Name("Usage")]
        public string Usage { get; set; }

        [Name("Fan In")]
        public string Fan_In { get; set; }

        [Name("Fan Out")]
        public string Fan_Out { get; set; }

        public string avg_fanIn { get; set; }
        public string avg_fanOut { get; set; }
        public string Modularity { get; set; }
    }
}
