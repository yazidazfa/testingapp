using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfTestingApp.model
{
    internal class ObjectList
    {
		private string? className = "";

		public string? ClassName
		{
			get { return className; }
			set { className = value; }
		}

		private string? objectName = "";

		public string? ObjectName
		{
			get { return objectName; }
			set { objectName = value; }
		}

		private int? objectUsage = 0;

		public int? ObjectUsage
		{
			get { return objectUsage; }
			set { objectUsage = value; }
		}

		private int? fanIn = 0;

		public int? FanIn
		{
			get { return fanIn; }
			set { fanIn = value; }
		}

        private int? fanOut = 0;

        public int? FanOut
        {
            get { return fanOut; }
            set { fanOut = value; }
        }

        private int? averageFanIn = 0;

        public int? AverageFanIn
        {
            get { return averageFanIn; }
            set { averageFanIn = value; }
        }

        private int? averageFanOut = 0;

        public int? AverageFanOut
        {
            get { return averageFanOut; }
            set { averageFanOut = value; }
        }

        private int? modularity = 0;

        public int? Modularity
        {
            get { return modularity; }
            set { modularity = value; }
        }
    }
}
