using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class DomainObject
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public DomainObject()
        {
        }

        public DomainObject(string name)
        {
            Name = name;
        }
    }
}
