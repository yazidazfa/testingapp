using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfTestingApp.model
{
    public sealed class csvMap : CsvHelper.Configuration.ClassMap<Data>
    {
        public csvMap()
        {
            // Menggunakan Map method untuk meng-map properties ke kolom-kolom CSV
            Map(m => m.Number).Name("Number");
            Map(m => m.Objects).Name("Class Name/Object");
            Map(m => m.Usage).Name("Usage");
            Map(m => m.Fan_In).Name("Fan In");
            Map(m => m.Fan_Out).Name("Fan Out");
            Map(m => m.avg_fanIn).Name("Average Fan In");
            Map(m => m.avg_fanOut).Name("Average Fan Out");
            Map(m => m.Modularity).Name("Modularity");

        }
    }
}
