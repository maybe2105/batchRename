using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace BatchRename
{
    public class Preset
    {
        public string RuleName { get; set; }

        public string Data { get; set; }

        public string Replacer { get; set; }

        public Preset()
        {

        }

        public Preset(string RuleName)
        {
            this.RuleName = RuleName;
        }

        public Preset(string RuleName,string Data){
            this.RuleName = RuleName;
            this.Data = Data;
        }
        public Preset(string RuleName,string Data,string Replacer)
        {
            this.RuleName = RuleName;
            this.Data = Data;
            this.Replacer = Replacer;
        }
    }
}
