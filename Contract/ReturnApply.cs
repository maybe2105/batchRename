using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class ReturnApply
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public ReturnApply(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }
    }
}
